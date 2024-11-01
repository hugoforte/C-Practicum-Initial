using Application.Interfaces;

namespace Application
{
    public class DishManager : IDishManager
    {
        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var retVal = new List<Dish>();
            order.DishTypeIds.Sort();
            foreach (var dishTypeId in order.DishTypeIds)
            {
                AddDishToList(dishTypeId, retVal);
            }
            return retVal;
        }

        /// <summary>
        /// Takes an int, representing a dish type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="dishTypeId">int, represents a dishtype</param>
        /// <param name="retVal">a list of dishes. </param>
        private void AddDishToList(int dishTypeId, List<Dish> retVal)
        {
            string dishName = GetDishNameByDishTypeId(dishTypeId);
            var existingDishInOrder = retVal.SingleOrDefault(x => x.DishName == dishName);
            if (existingDishInOrder == null)
            {
                retVal.Add(new Dish
                {
                    DishName = dishName,
                    Count = 1
                });
            }
            else if (AreMultiplesAllowedByDishTypeId(dishTypeId))
            {
                existingDishInOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", dishName));
            }
        }

        private string GetDishNameByDishTypeId(int dishTypeId)
        {
            return dishTypeId switch
            {
                1 => "steak",
                2 => "potato",
                3 => "wine",
                4 => "cake",
                _ => throw new ApplicationException("Order does not exist"),
            };
        }


        private bool AreMultiplesAllowedByDishTypeId(int dishTypeId)
        {
            return dishTypeId switch
            {
                2 => true,
                _ => false,
            };
        }
    }
}