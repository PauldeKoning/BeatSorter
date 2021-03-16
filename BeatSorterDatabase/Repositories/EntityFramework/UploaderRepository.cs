using BeatSorterDatabase.Entities;
using BeatSorterDatabase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeatSorterDatabase.Repositories.EntityFramework
{
    public class UploaderRepository : IUploaderRepository
    {
        private readonly BeatSorterContext context;

        public UploaderRepository(BeatSorterContext context)
        {
            this.context = context;
        }

        public UploaderEntity GetUploaderById(int id)
        {
            return context.Uploader.FirstOrDefault(u => u.Id == id);
        }

        public UploaderEntity GetUploaderByBeatSaverId(string beatSaverId)
        {
            return context.Uploader.FirstOrDefault(u => u.BeatSaverId == beatSaverId);
        }

        public void InsertUploader(UploaderEntity uploader)
        {
            context.Uploader.Add(uploader);
            context.SaveChanges();
        }
    }
}
