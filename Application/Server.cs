using Application.Interfaces;

namespace Application
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }

        public string TakeOrder(string unparsedOrder)
        {
            try
            {

                Order order = ParseOrder(unparsedOrder);

                List<Dish> dishes = _dishManager.GetDishes(order);

                string retVal = FormatOutput(dishes);

                return retVal;
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }

        private Order ParseOrder(string order)
        {
            var dishTypeIds = order.Split(',');
            var retVal = new List<int>();
            foreach (var dishTypeId in dishTypeIds)
            {
                if (int.TryParse(dishTypeId, out int parsedOrder))
                {
                    retVal.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be comma separated list of numbers");
                }
            }
            return new Order
            {
                DishTypeIds = retVal
            };
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var retVal = "";

            foreach (var dish in dishes)
            {
                retVal += string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }
            if (retVal.StartsWith(","))
            {
                retVal = retVal.TrimStart(',');
            }
            return retVal;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
