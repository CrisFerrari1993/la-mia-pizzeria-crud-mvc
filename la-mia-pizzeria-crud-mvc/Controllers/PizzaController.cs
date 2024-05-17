using la_mia_pizzeria_crud_mvc.Data;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(PizzaManager.GetPizzas());
        }

        public IActionResult Show(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza != null)
                return View(pizza);
            else
                return View("errore");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            using (PizzaContext db = new PizzaContext())
            {
                var pizzaToCreate = new Pizza(data.Name, data.Description, data.Price);
                db.Pizzas.Add(pizzaToCreate);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var pizzaToEdit = PizzaManager.GetPizza(id);

            if (pizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View(pizzaToEdit);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", data);
            }

            bool res = PizzaManager.UpdatePizza(id, pizzaToEdit =>
            {
                pizzaToEdit.Name = data.Name;
                pizzaToEdit.Description = data.Description;
                pizzaToEdit.Price = data.Price;
            });

            if (res == true)
                return RedirectToAction("Index");
            else
                return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
