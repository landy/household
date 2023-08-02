namespace Household.Recipes

open System

type Recipe = {
    Id: Guid
    Name: string
    PreparationTime: TimeSpan option
    Description: string
    Ingredients: string
}
