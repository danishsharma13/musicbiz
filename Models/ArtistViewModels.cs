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

    // Artist Base View Model
    public class ArtistBaseViewModel
    {
        // Default Values for Properties
        public ArtistBaseViewModel()
        {
            BirthOrStartDate = DateTime.Now;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name or Stage Name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Birth Name (If Applicable)")]
        public string BirthName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birth / Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Executive Responsible")]
        public string Executive { get; set; }
    }

    // Artist With Details View Model
    public class ArtistWithDetailsViewModel : ArtistBaseViewModel
    {
        // Default Values for Properties
        public ArtistWithDetailsViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Portrayal of Artist")]
        public string Portrayal { get; set; }

        // Navigation

        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }
    }

    // Artist With Media Info View Model
    public class ArtistWithMediaInfoViewModel : ArtistWithDetailsViewModel
    {
        public ArtistWithMediaInfoViewModel()
        {
            ArtistMediaItems = new List<ArtistMediaItemBaseViewModel>();
        }

        public IEnumerable<ArtistMediaItemBaseViewModel> ArtistMediaItems { get; set; }
    }

    // Artist Add Form View Model
    public class ArtistAddFormViewModel
    {
        // Default Values for Properties
        public ArtistAddFormViewModel()
        {
            BirthOrStartDate = DateTime.Now;
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name or Stage Name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Birth Name (If Applicable)")]
        public string BirthName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth / Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Artist Photo (URL)")]
        public string UrlArtist { get; set; }

        [Display(Name = "Primary Genre")]
        public SelectList GenreList { get; set; }

        [Display(Name = "Executive Responsible")]
        public string Executive { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Portrayal of Artist")]
        public string Portrayal { get; set; }
    }

    // Artist Add View Model
    public class ArtistAddViewModel
    {
        // Default Values for Properties
        public ArtistAddViewModel()
        {
            BirthOrStartDate = DateTime.Now;
            Albums = new List<AlbumBaseViewModel>();
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name or Stage Name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Birth Name (If Applicable)")]
        public string BirthName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birth / Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Display(Name = "Executive Responsible")]
        public string Executive { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Portrayal of Artist")]
        public string Portrayal { get; set; }

        // Navigation

        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }
    }
}