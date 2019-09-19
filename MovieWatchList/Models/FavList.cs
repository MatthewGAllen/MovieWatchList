using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWatchList.Models
{
    public class FavList
    {
        [Key]
        public int FavId { get; set; }
        public bool Star { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual MovieInfo MovieInfo { get; set; }

    }
}
