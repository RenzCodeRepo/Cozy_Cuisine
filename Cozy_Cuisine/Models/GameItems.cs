﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class GameItems
    {
        [Key]
        public int ItemId { get; set; }
        public int WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual Wiki Wiki { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> URLImageList { get; set; }
        public string URLGif { get; set; }
    }
}
