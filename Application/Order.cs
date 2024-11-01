namespace Application
{
    public class Order
    {
        public Order()
        {
            DishTypeIds = [];
        }

        /// <summary>
        /// List of dish types (entrée's, sides, drinks, and desserts)
        /// </summary>
        public List<int> DishTypeIds { get; set; }
    }
}