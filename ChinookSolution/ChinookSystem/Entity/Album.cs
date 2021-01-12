using System;
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
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;

        [Key]
        public int AlbumId { get; set; }
        [Required(ErrorMessage ="Album title is required")]
        [StringLength(160, ErrorMessage = ("album title is limited to 160 characters"))]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        [StringLength(50, ErrorMessage = ("Release Label is limited to 50 characters"))]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set
            {
                _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value;
            }
        }

        //[NotMapped] annotations also allowed 

        //navigational properties
        // many to one direction (child to parent)
        public virtual Artist Artist { get; set; }
    }
}
