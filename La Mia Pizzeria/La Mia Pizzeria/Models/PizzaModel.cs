using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using La_Mia_Pizzeria.Models.CustomValidations;

namespace La_Mia_Pizzeria.Models
{
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        [StringLength(30, ErrorMessage = "Il seguente campo deve contenere un massimo di 30 caratteri.")]
        public string Name { get; set; }
        
        [StringLength(400, ErrorMessage ="Il seguente campo deve contenere un massimo di 400 caratteri.")]
        [Column(TypeName = "text")]
        [Required(ErrorMessage ="Il campo è obbligatorio.")]
        [MoreThanFiveWords]
        public string Description { get; set; }

        [MaxLength(300)]
        [StringLength(200, ErrorMessage = "Il seguente campo deve contenere un massimo di 200 caratteri.")]
        [Url(ErrorMessage ="Deve essere un Url valido.")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        public string ImgSource { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        [Range(5,30,ErrorMessage ="Il prezzo non può essere inferiore a 5€, nè maggiore di 30€.")]

        public float Price { get; set; }


        public int? CathegoryId { get; set; }
        public CathegoryModel? Cathegory { get; set; }


        public PizzaModel(string name, string description, string imgSource, float price)
        {
            this.Name = name;
            this.Description = description;
            this.ImgSource = imgSource;
            this.Price = price;
        }

        public PizzaModel()
        {

        }

    }
}
