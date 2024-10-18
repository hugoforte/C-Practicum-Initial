namespace Application
{
    /// <summary>
    /// Contains a dish by name and number of times the dish has been ordered
    /// </summary>
    public class Dish
    {
        public required string DishName { get; set; }
        public int Count { get; set; }
    }
}