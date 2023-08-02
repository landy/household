namespace Household.Recipes


type IRecipesStorage =
    abstract member SaveRecipe : Recipe -> Async<unit>