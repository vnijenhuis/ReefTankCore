using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public interface IMediaService
    {
        void AddMediaFile(Media media);
        void SaveMediaFile(Media media);
        Media GetMediaFile(Guid id);
        Media GetMediaFile(Creature creature);
        Media InsertMedia(IFormFile formfile, string directory);
        void Delete(Media categoryMedia);
    }
}
