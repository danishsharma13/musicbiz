using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2022A6DS.Models
{
    // ==========================================================

    // I have used my own Display(Name...) for this assignment.
    // The screenshot provided in the assignment were looking 
    // a little too long. Just wanted to make it neat and simple.

    // ==========================================================

    // Album Base View Model
    public class AlbumBaseViewModel
    {
        // Default Values for Properties
        public AlbumBaseViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Album Image / Cover Art (URL)")]
        public string UrlAlbum { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Coordinator Responsible")]
        public string Coordinator { get; set; }
    }

    // Album With Details View Model
    public class AlbumWithDetailsViewModel : AlbumBaseViewModel
    {
        public AlbumWithDetailsViewModel()
        {
            Artists = new List<ArtistBaseViewModel>();
            Tracks = new List<TrackBaseViewModel>();
        }

        [Display(Name = "Artists with this Album")]
        public IEnumerable<string> ArtistNames { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Background of Album")]
        public string Background { get; set; }

        // Navigation

        public IEnumerable<ArtistBaseViewModel> Artists { get; set; }

        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }
    }

    // Album Add Form View Model
    public class AlbumAddFormViewModel
    {
        // Default Values for Properties
        public AlbumAddFormViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Album Image / Cover Art (URL)")]
        public string UrlAlbum { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Display(Name = "Primary Genre")]
        public SelectList GenreList { get; set; }

        [Display(Name = "Coordinator Responsible")]
        public string Coordinator { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Background of Album")]
        public string Background { get; set; }

        // No need for this assignment
        /*
        [Display(Name = "All Artists")]
        public MultiSelectList ArtistList { get; set; }

        [Display(Name = "All Tracks")]
        public MultiSelectList TrackList { get; set; }
        */
    }

    // Album Add View Model
    public class AlbumAddViewModel
    {
        // Default Values for Properties
        public AlbumAddViewModel()
        {
            ReleaseDate = DateTime.Now;
            // No need for this assignment
            /*
            ArtistIds = new HashSet<int>();
            TrackIds = new HashSet<int>();
            */
            Artists = new List<ArtistBaseViewModel>();
            Tracks = new List<TrackBaseViewModel>();
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Album Image / Cover Art (URL)")]
        public string UrlAlbum { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Display(Name = "Coordinator Responsible")]
        public string Coordinator { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Background of Album")]
        public string Background { get; set; }

        // No need for this assignment
        /*
        public IEnumerable<int> ArtistIds { get; set; }

        public IEnumerable<int> TrackIds { get; set; }
        */

        // Navigation

        public IEnumerable<ArtistBaseViewModel> Artists { get; set; }

        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }
    }
}