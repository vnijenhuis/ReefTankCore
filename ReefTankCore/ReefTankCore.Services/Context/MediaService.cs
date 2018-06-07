using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public class MediaService : IMediaService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ReefContext _reefContext;

        public MediaService(ReefContext reefContext, IHostingEnvironment hostingEnvironment)
        {
            _reefContext = reefContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public void AddMediaFile(Media media)
        {
            _reefContext.Media.Add(media);
        }

        public void SaveMediaFile(Media media)
        {
            _reefContext.Media.Update(media);
        }

        public Media GetMediaFile(Guid id)
        {
            return _reefContext.Media.Find(id);
        }

        public Media GetMediaFile(Creature creature)
        {
            return _reefContext.Media.First(x => x.Id == creature.MediaId);
        }

        public Media InsertMedia(IFormFile formfile, string directory)
        {
            //Determine directory
            var webRoot = _hostingEnvironment.WebRootPath + directory;
            if (!Directory.Exists(webRoot))
            {
                Directory.CreateDirectory(webRoot);
            }

            var path = Path.Combine(webRoot, formfile?.FileName);
            if (!System.IO.File.Exists(path))
            {
                
                using (var fs = System.IO.File.Create(path))
                {
                    formfile.CopyTo(fs);
                    fs.Flush();
                    fs.Close();
                }
            }

            //Create media object.
            var media = new Media()
            {
                ContentType = formfile.ContentType,
                Filename = formfile.FileName,
                Url = directory,
            };

            SaveMediaFile(media);
            return media;
        }

        public void Delete(Media categoryMedia)
        {
            _reefContext.Media.Remove(categoryMedia);
        }
    }
}
