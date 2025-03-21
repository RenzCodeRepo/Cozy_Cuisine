﻿using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Patches
    {
        [Key]
        public int PatchId { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string PatchNotes { get; set; }
        public List<string> URLImageList { get; set; }
        public string URLGif { get; set; }

        public ICollection<BugReport> BugReport { get; set; }
    }
}
