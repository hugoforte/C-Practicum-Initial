namespace Application.Interfaces
{
    public interface IDishManager
    {
        List<Dish> GetDishes(Order order);
    }
}