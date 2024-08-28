namespace FoodMenu.Models
{
    public class PlateIngredient
    {
        public int PlateId { get; set; }
        public Plate Plate { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
