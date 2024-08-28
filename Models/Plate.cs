namespace FoodMenu.Models
{
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }

        public List<PlateIngredient>? PlateIngredients { get; set; }
    }
}
