using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DS.Data
{
    public class ArtistMediaItem
    {
        // Default values
        public ArtistMediaItem()
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

        public byte[] Content { get; set; }

        // Navigation

        [Required]
        public Artist Artist { get; set; }
    }
}