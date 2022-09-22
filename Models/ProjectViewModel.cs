using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Portfolio_Dev.Models
{
    [Table("project")]
    public class ProjectViewModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string name { get; set; }
        [Display(Name = "Descrição")]
        public string describle { get; set; }
       
        public string urlImage { get;set; }
        [Display(Name="Link do github")]
        public string linkgithub { get; set; }

    }    
}
