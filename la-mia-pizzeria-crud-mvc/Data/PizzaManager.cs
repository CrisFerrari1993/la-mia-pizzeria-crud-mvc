using Microsoft.Extensions.Hosting;
using System.Collections.Specialized;

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

        public static bool UpdatePizza(int id, Action<Pizza> edit) 
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);

            if (pizza == null)
                return false;

            edit(pizza);

            db.SaveChanges();

            return true;
        }

        public static bool UpdatePizza(int id, string name, string description, float price)
        {
            using PizzaContext db =new PizzaContext();
            var pizza = db.Pizzas.FirstOrDefault(p =>p.PizzaId == id);

            if(pizza == null)
                return false;

            pizza.Name = name;
            pizza.Description = description;
            pizza.Price = price;

            db.SaveChanges();

            return true;
        }

        public static bool DeletePizza(int id)
        {
            using PizzaContext db =new PizzaContext();
            var pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);

            if(pizza == null)
                return false;
            
            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return true;
                
        }
    }
}
