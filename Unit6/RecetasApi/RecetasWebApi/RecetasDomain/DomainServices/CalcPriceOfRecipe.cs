using RecetasDomain.DomainEntities;

namespace RecetasDomain.DomainServices
{
    public class CalcPriceOfRecipe
    {

        public static decimal? PriceOfIngredients(RecipesInfo quantityIngredientsAndTimeOfCooking,
                                                List<PricesInfo> pricesIngredientsList)
        {
            decimal? totalPrice = 0;

            for (int i = 0; i < pricesIngredientsList.Count; i++)
            {
                if (quantityIngredientsAndTimeOfCooking.Ingredients.ContainsKey(pricesIngredientsList[i].Name))
                {
                    quantityIngredientsAndTimeOfCooking.Ingredients.TryGetValue(pricesIngredientsList[i].Name, out decimal value);
                    decimal? price = pricesIngredientsList[i].Price * value;

                    totalPrice += price;
                }
            }

            return totalPrice;
        }

        public static decimal? PriceOfCooked(RecipesInfo quantityIngredientsAndTimeOfCooking, PriceTimeInfo priceForMinute)
        {
            return quantityIngredientsAndTimeOfCooking.TimeMinutes * priceForMinute.Price;
        }
    }
}
