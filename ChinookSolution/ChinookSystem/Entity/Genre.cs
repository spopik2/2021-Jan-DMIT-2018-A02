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
    [Table("Genres")]
    internal class Genre
    {
        private string _Name;
        [Key]
        public int GenresId { get; set; }
        [StringLength(120, ErrorMessage ="Genre name is limited to 120 characters")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}