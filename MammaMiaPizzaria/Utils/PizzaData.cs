using MammaMiaPizzaria.Models;

namespace MammaMiaPizzaria.Utils
{
    public static class PizzaData
    {
        private static List<Pizza> Pizze;

        public static List<Pizza> GetPizze()
        {
            //controllo che la lista di pizze non sia vuota
            if (Pizze != null)
            {
                return PizzaData.Pizze;
            }

            //Creo una lista provvisoria
            List<Pizza> NuovePizze = new List<Pizza>();

            //creo variabile contatore che mi farà da id
            

            //istanzio un oggetto per ogni elemento della lista e la salvo nella lista provvisoria
            Pizza pizza = new Pizza(0, "Margherita", "mozzarella, pomodoro, olio di oliva, basilico", "https://shop.benazzoli.com/wp-content/uploads/2019/05/pizza-margherita_1200x800.jpg", Math.Round(4.00, 2));
            NuovePizze.Add(pizza);
            Pizza pizza2 = new Pizza(1, "Marinara", "pomodoro, olio di oliva, basilico, aglio", "https://primochef.it/wp-content/uploads/2018/05/SH_pizza_alla_marinara-1200x800.jpg", Math.Round(3.50, 2));
            NuovePizze.Add(pizza2);
            Pizza pizza3 = new Pizza(2, "Quattro Formaggi", "mozzarella, pomodoro, olio di oliva, taleggio, crescenza, zola", "https://www.panineriatrentaelode.it/wp-content/uploads/2021/01/Pizza-4-formaggi-pizzeria-30-e-lode-1.jpg", Math.Round(7.50, 2));
            NuovePizze.Add(pizza3);
            Pizza pizza4 = new Pizza(3, "Salame Piccante", "mozzarella, pomodoro, olio di oliva, salame piccante", "https://cdn.agrodolce.it/rbBVUaq8bErMgLcVmw2X5uXeNew=/1200x800/smart/https://www.agrodolce.it/app/uploads/2019/04/shutterstock-1239982861.jpg", Math.Round(6.50, 2));
            NuovePizze.Add(pizza4);
            Pizza pizza5 = new Pizza(4, "Ortolana", "mozzarella, pomodoro, olio di oliva, zucchine, melanzane, peperoni", "https://blog.giallozafferano.it/piovonoricette/wp-content/uploads/2018/02/IMG_2164.jpg", Math.Round(6.50, 2));
            NuovePizze.Add(pizza5);
            Pizza pizza6 = new Pizza(5, "Kebap", "mozzarella, pomodoro, olio di oliva, Kebap, cipolle, salsa yogurt, lattuga, salsa piccante, pomodori", "https://i1.wp.com/istanbulmalnate.it/wp-content/uploads/2020/02/doner.jpg", Math.Round(7.50, 2));
            NuovePizze.Add(pizza6);
            Pizza pizza7 = new Pizza(6, "Scamorza Crudo e Rosmarino", "mozzarella, pomodoro, olio di oliva, basilico, scamorza, prosciutto crudo, rosmarino", "https://www.ristoranteserenella.it/wp-content/uploads/2019/03/dinamite-pizza.jpg", Math.Round(6.50, 2));
            NuovePizze.Add(pizza7);
            Pizza pizza8 = new Pizza(7, "Bufalona", "mozzarella di Bufola, pomodoro, olio di oliva, basilico", "https://static.gamberorosso.it/2020/10/fratelli-cuore.jpg", Math.Round(6.50, 2));
            NuovePizze.Add(pizza8);
            Pizza pizza9 = new Pizza(8, "Diavolo Blu", "mozzarella, pomodoro, olio di oliva, basilico, Zola, Nduja Calabra", "https://static.gamberorosso.it/2020/06/marasco-96ore-ricotta-nduja-bassa.jpg", Math.Round(8.00, 2));
            NuovePizze.Add(pizza9);

            PizzaData.Pizze = NuovePizze;

            //ritorno la lista compilata
            return PizzaData.Pizze;
        }
    }
}
