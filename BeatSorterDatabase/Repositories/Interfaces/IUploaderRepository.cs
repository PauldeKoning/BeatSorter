using BeatSorterDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeatSorterDatabase.Repositories.Interfaces
{
    public interface IUploaderRepository
    {
        public void InsertUploader(UploaderEntity uploader);
        public UploaderEntity GetUploaderByBeatSaverId(string beatSaverId);
        public UploaderEntity GetUploaderById(int id);
    }
}
