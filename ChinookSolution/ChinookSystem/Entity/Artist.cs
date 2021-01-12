﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion
namespace ChinookSystem.Entity
{
    [Table("Artists")]
    internal class Artist
    {
        private string _Name;

        [Key]
        public int ArtistID { get; set; }
        [StringLength(120, ErrorMessage =("Artist Name is limited to 120 characters"))]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = string.IsNullOrEmpty(value) ? null : value;
            }
        }
    }
}
