using BeatSorter.Entities;
using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Util.Converters
{
    public class UploaderConverter
    {

        public static UploaderEntity ToEntity(Uploader uploader)
        {
            return new UploaderEntity
            {
                Id = uploader.Id,
                BeatSaverId = uploader.BeatSaverId,
                Username = uploader.Username,
            };
        }

        public static Uploader ToModel(UploaderEntity uploader)
        {
            return new Uploader()
            {
                Id = uploader.Id,
                BeatSaverId = uploader.BeatSaverId,
                Username = uploader.Username
            };
        }

    }
}
