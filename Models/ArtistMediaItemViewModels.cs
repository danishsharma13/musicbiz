using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DS.Models
{
    // ArtistMediaItemBaseViewModel
    public class ArtistMediaItemBaseViewModel
    {
        // Default values
        public ArtistMediaItemBaseViewModel()
        {
            Timestamp = DateTime.Now;

            // StringId generator
            // Code is from Mads Kristensen
            // http://madskristensen.net/post/generate-unique-strings-and-numbers-in-c

            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string StringId { get; set; }

        [Required]
        [StringLength(100)]
        public string Caption { get; set; }

        public DateTime Timestamp { get; set; }

        // Media Item
        [StringLength(200)]
        public string ContentType { get; set; }
    }

    // ArtistMediaItemContentViewModel
    public class ArtistMediaItemContentViewModel
    {
        public int Id { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

    }

    // ArtistMediaItemAddFormViewModel
    public class ArtistMediaItemAddFormViewModel
    {
        [Required]
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Artist MediaItem")]
        [DataType(DataType.Upload)]
        public string ArtistMediaItemUpload { get; set; }
    }

    // ArtistMediaItemAddViewModel
    public class ArtistMediaItemAddViewModel
    {
        [Required]
        public int ArtistId { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase ArtistMediaItemUpload { get; set; }
    }
}