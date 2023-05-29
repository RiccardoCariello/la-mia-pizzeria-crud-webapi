using Microsoft.AspNetCore.Mvc;
using La_Mia_Pizzeria.Models;
using La_Mia_Pizzeria.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using La_Mia_Pizzeria.Models.ModelForView;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria.Controllers
{
    
    public class PizzaController : Controller
    {
        
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizze.Include(p=>p.Cathegory).ToList();

                return View(pizze);
            }



        }
        
        
        
        //[Authorize(Roles = "ADMIN,USER")]
        [HttpGet]
        public IActionResult PizzaDetails(int Id)
        {

            using (PizzaContext db = new PizzaContext())
            {

                PizzaModel? pizza = db.Pizze.Where(pizze => pizze.Id == Id).Include(categoria => categoria.Cathegory).FirstOrDefault();

                if (pizza != null)
                {


                    return View("PizzaDetails", pizza);
                } else
                {
                    return NotFound($"Nessuna pizza trovata con l'Id {Id}");
                }
            }
        }



        //[Authorize(Roles = "ADMIN,USER")]
        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<CathegoryModel> cathegories = db.Categorie.ToList();

                PizzaListCathegory cathegoryList = new PizzaListCathegory();

                cathegoryList.Pizze = new PizzaModel();
                cathegoryList.Categorie  = cathegories;
                return View("Create", cathegories);
            }


                
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaListCathegory data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<CathegoryModel> cathegories = db.Categorie.ToList();
                    data.Categorie = cathegories;
                    return View("Create", data);
                }
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel pizzaToCreate = new PizzaModel(data.Pizze.Name, data.Pizze.Description, data.Pizze.ImgSource, data.Pizze.Price);
                pizzaToCreate.CathegoryId = data.Pizze.CathegoryId;
                db.Pizze.Add(pizzaToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }



        [Authorize(Roles = "ADMIN")]
        [HttpGet] public IActionResult Update(int id) {


            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaModificare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaModificare != null)
                {   //se l'oggetto non è nullo significa che il progrtmma ha correttamente trovato l'articolo che vogliamo modificare, quindi ci ritornerà
                    //la view passando come modello la pizza trovata
                    //edit ora passa un oggetto speciale contenente pizza e categorie

                    List<CathegoryModel> categorie = db.Categorie.ToList();

                    PizzaListCathegory model = new PizzaListCathegory();
                    model.Pizze = pizzaDaModificare;
                    model.Categorie = categorie;
                    
                    
                    return View("Update", model);
                }
                else
                {
                    return NotFound();
                }

            }

        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaListCathegory data)
        {

            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<CathegoryModel> categorie = db.Categorie.ToList();
                    data.Categorie = categorie;


                    return View("Update", data);
                }
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaModificare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaDaModificare != null)
                {
                    pizzaDaModificare.Name = data.Pizze.Name;
                    pizzaDaModificare.Description = data.Pizze.Description;
                    pizzaDaModificare.ImgSource = data.Pizze.ImgSource;
                    pizzaDaModificare.Price = data.Pizze.Price;
                    pizzaDaModificare.CathegoryId = data.Pizze.CathegoryId;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaCancellare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if(pizzaDaCancellare != null)
                {
                    db.Remove(pizzaDaCancellare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Non ho trovato la pizza che vorresti cancellare.");
                }
            }

        }

    }
}
