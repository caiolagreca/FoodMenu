namespace FoodMenu.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PlateIngredient>? PlateIngredients { get; set; }
    }
}
