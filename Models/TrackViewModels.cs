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

    // Track Base View Model
    public class TrackBaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Composer Names (Comma-Seperated)")]
        public string Composers { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Clerk Responsible")]
        public string Clerk { get; set; }
    }

    // Track With Details View Model
    public class TrackWithDetailsViewModel : TrackBaseViewModel
    {
        // Default Values for Properties
        public TrackWithDetailsViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }


        // Navigation
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }
    }

    // Track Add Form View Model
    public class TrackAddFormViewModel
    {
        // Default Values for Properties
        public TrackAddFormViewModel()
        {
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Composer Names (Comma-Seperated)")]
        public string Composers { get; set; }

        [Display(Name = "Album ID")]
        public int AlbumId { get; set; }

        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Display(Name = "Track Genre")]
        public SelectList GenreList { get; set; }

        [Display(Name = "Clerk Responsible")]
        public string Clerk { get; set; }

        [Required]
        [Display(Name = "Sample Clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }

    // Track Add View Model
    public class TrackAddViewModel
    {
        // Default Values for Properties
        public TrackAddViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Composer Names (Comma-Seperated)")]
        public string Composers { get; set; }

        [Display(Name = "Album ID")]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Genre")]
        public string Genre { get; set; }

        public string Clerk { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase AudioUpload { get; set; }

        // Navigation
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }
    }

    // TrackAudioViewModel
    public class TrackAudioViewModel
    {
        public int Id { get; set; }
        public string AudioContentType { get; set; }
        public byte[] Audio { get; set; }
    }

    // TrackEditFormViewModel
    public class TrackEditFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sample Clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }

    // TrackEditViewModel
    public class TrackEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
}