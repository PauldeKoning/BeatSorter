using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorterDatabase.Entities
{
    [Table("uploader")]
    public class UploaderEntity
    {

        public int Id { get; set; }

        public string BeatSaverId { get; set; }

        public string Username { get; set; }

        public ICollection<BeatmapEntity> Beatmaps { get; set; }

    }
}
