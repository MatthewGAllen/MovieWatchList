using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWatchList.Models
{
    public class MovieInfo
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }

        public string Genre { get; set; }
        public string Description { get; set; }
        //public string Image { get; set; }


    }
}
