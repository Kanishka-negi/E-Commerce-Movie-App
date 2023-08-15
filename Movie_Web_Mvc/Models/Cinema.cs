using System.ComponentModel.DataAnnotations;

namespace Movie_Web_Mvc.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
        //[Key]
        //public int Id { get; set; }
        //public string Logo { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }

        ////Relationship
        //public List<Movie> Movies { get; set; }
 


