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
    [Table("Tracks")]
    internal class Track
    {
        private string _Composer;
        [Key]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "Track name is required")]
        [StringLength(200, ErrorMessage = "Track name is limited to 200 characters")]
        public string Name { get; set; }
        public int AlbumId { get; set; }
        [Required(ErrorMessage = "Media type ID is required")]
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        [StringLength(220, ErrorMessage = "Composer is limited to 220 characters")]
        public string Composer
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
        }
        [Required(ErrorMessage = "Milliseconds is required")]
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        [Required(ErrorMessage = "Unit Price is required")]
        public int UnitPrice { get; set; }
        public virtual Genre Genres { get; set; }
        public virtual Album Albums { get; set; }
        public virtual MediaType MediaTypes { get; set; }

    }
}
