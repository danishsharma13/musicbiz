using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A6DS.Models
{
    // ==========================================================

    // I have used my own Display(Name...) for this assignment.
    // The screenshot provided in the assignment were looking 
    // a little too long. Just wanted to make it neat and simple.

    // ==========================================================

    // Genre Base View Model
    public class GenreBaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
    }
}