using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class PizzaManager
    {
        public static List<Pizza> GetPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            return GetPizzas().FirstOrDefault(p => p.PizzaId == id);
        }

        public static void InsertPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

    }
}
