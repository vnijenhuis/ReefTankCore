using System;
using System.Collections.Generic;
using System.Text;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    interface IMediaService
    {
        void AddMediaFile(Media media);
        void SaveMediaFile(Media media);
        Media GetMediaFile(Guid id);
        Media GetMediaFile(Creature creature);
    }
}
