using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

using La_Mia_Pizzeria.Models.CustomValidations;

namespace La_Mia_Pizzeria.Models
{
    public class CathegoryModel
    {
        [Key]
        public int Id { get; set; }



        [MaxLength(20)]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        [StringLength(30, ErrorMessage = "Il seguente campo deve contenere un massimo di 20 caratteri.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<PizzaModel> pizzaModels { get; set; }

        public CathegoryModel() 
        { 
        
        }

        public CathegoryModel(string name, string? description)
        {
            Name = name;

            Description = description;

            pizzaModels = new List<PizzaModel>(); 


        }



    }
}
