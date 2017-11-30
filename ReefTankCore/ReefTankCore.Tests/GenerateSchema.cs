using System;
using System.IO;
using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;

namespace ReefTankCore.Tests
{
    [TestFixture]
    public class GenerateSchema
    {
        /// <summary>
        /// Initializes the Models assembly for activerecord.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            try
            {
                if (ActiveRecordStarter.IsInitialized)
                {
                    return;
                }

                //Gets the assembly in which the Character model is present
                var assembly = Assembly.GetAssembly(typeof(Creature));

                //Get path of current bin directory and then navifates to the xml file.
                var path = TestContext.CurrentContext.TestDirectory + "../../../ActiveRecord.Test.xml";

                XmlConfigurationSource config = new XmlConfigurationSource(path);

                //Initilaize activerecord with given configuration
                ActiveRecordStarter.Initialize(assembly, config);
            }
            catch (InvalidOperationException exception)
            {
                string causeOfException =
                    "Het domein-model kan niet worden geinitaliseerd. Er is een fout opgetreden: " +
                    "De instelling, die aangeeft waar de configuratie voor het " +
                    "ORM framework zich bevind, kan niet worden geladen. ";

                throw new InvalidOperationException(causeOfException, exception);
            }
            catch (Exception exception)
            {
                // Er is een onbekende fout opgetreden.
                string causeOfException =
                    "Het domein-model kan niet worden geinitaliseerd. Er is een onbekende fout opgetreden.";

                throw new Exception(causeOfException, exception);
            }
        }

        /// <summary>
        /// Generate an SQL file based on the provided datamodel.
        /// </summary>
        [Test]
        public void Generate()
        {
            var currentDate = DateTime.Now.ToString("ddMMyyyy");

            var creationFile = string.Format(TestContext.CurrentContext.TestDirectory + "../../../Schemas\\schema-{0}.sql", currentDate);

            ActiveRecordStarter.GenerateCreationScripts(creationFile);

            PrependDatabaseCreation(creationFile, currentDate);
        }

        private static void PrependDatabaseCreation(string path, string databaseVersionNumber)
        {
            var pathOfTemporaryFile = path + ".temp";

            //Remove temporary file if it exists.
            File.Delete(pathOfTemporaryFile);

            //Rename SQL script to the temporary file
            File.Move(path, pathOfTemporaryFile);

            using (StreamReader sr = new StreamReader(pathOfTemporaryFile))

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                // Schrijf het aanmaken van de database naar het sql script.
                sw.WriteLine("/* Maak de tabellen en contraints aan. */");

                // Kopieer de inhoud van het tijdelijke bestand (de stream reader)
                // naar het sql script (de stream writer).
                CopyFromStreamReaderToWriter(sw, sr);
            }
            File.Delete(pathOfTemporaryFile);
        }

        private static void CopyFromStreamReaderToWriter(StreamWriter streamWriter, StreamReader streamReader)
        {
            char[] buffer = new char[10000];

            int read;

            while ((read = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                streamWriter.Write(buffer, 0, read);
        }
    }
}
