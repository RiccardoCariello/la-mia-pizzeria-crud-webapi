using La_Mia_Pizzeria.Database;
using La_Mia_Pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace La_Mia_Pizzeria.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        /*Deve avere un metodo GetPizzas() che restituisca la lista delle pizze che offre la nostra pizzeria.
Un metodo per ricercare tramite il titolo della pizza le pizze che hanno nel proprio titolo la stringa specificata
Un metodo che dato l'id di una pizza restituisca le info sulla pizza con quel id*/
        [HttpGet]
        public IActionResult GetPizza()
        {
            using (PizzaContext db = new PizzaContext())
            {

                List<PizzaModel> pizzaList = db.Pizze.ToList();
                return Ok(pizzaList);

            }
        }

        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? PizzaFound = db.Pizze.Where(pizza => pizza.Name.Contains(name)).FirstOrDefault();
                if (PizzaFound != null)
                {
                    return Ok(PizzaFound);
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpGet("{id}")]

        public IActionResult SearchById(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? PizzaFound = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (PizzaFound != null)
                {
                    return Ok(PizzaFound);
                }
                else
                {
                    return NotFound();
                }

            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] PizzaModel pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                using(PizzaContext db = new PizzaContext())
                {
                    db.Pizze.Add(pizza);
                    db.SaveChanges();

                    return Ok();
                }
            }
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                PizzaModel pizza = db.Pizze.Where(pizza => pizza.Id==id).FirstOrDefault();

                if(pizza != null)
                {
                    db.Remove(pizza);
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
