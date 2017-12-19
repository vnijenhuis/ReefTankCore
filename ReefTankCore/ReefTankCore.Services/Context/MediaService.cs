using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public class MediaService : IMediaService
    {
        private readonly ReefContext _reefContext;

        public MediaService(ReefContext reefContext)
        {
            _reefContext = reefContext;
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
            return _reefContext.Media.First(x => x.CreatureId == creature.Id);
        }
    }
}
