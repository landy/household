namespace Household.Recipes

open System

type CreateRecipeDto = {
    Name: string
    PreparationTime: TimeSpan option
    Description: string
    Ingredients: string
}

type RecipesService = {
    CreateRecipe : CreateRecipeDto -> Async<Result<Guid, string>>
}
with
    static member RouteBuilder _ m = sprintf "/api/recipes/%s" m

