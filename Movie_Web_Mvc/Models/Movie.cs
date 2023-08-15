using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie_Web_Mvc.Models
{
 
        public class Movie
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }
            public string Description { get; set; }

            public double Price { get; set; }

            public string Logo { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public string MovieCategory { get; set; }

            //Relatinonship
            public int CinemaId { get; set; }
            [ForeignKey("CinemaId")]
            public Cinema Cinema { get; set; }



        }
    }

