[<RequireQualifiedAccess>]
module Household.Recipes.RecipesApi


open System
open System.Threading.Tasks
open Giraffe
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Giraffe.GoodRead
open Microsoft.Extensions.Logging

module private Handlers =
    let createRecipeHandler
        (recipesStorage: IRecipesStorage)
        : CreateRecipeDto -> Task<Result<Guid, string>> =
        fun (recipe: CreateRecipeDto) ->
            task { return Guid.Empty |> Result<Guid, string>.Ok }

let private recipesApiReader =
    reader {
        let! recipesStorage = resolve<IRecipesStorage> ()

        return {
            CreateRecipe =
                Handlers.createRecipeHandler recipesStorage >> Async.AwaitTask
        }

    }

let httpHandler: HttpHandler =
    let remoting logger =
        Remoting.createApi ()
        |> Remoting.withRouteBuilder RecipesService.RouteBuilder
        |> Remoting.fromReader recipesApiReader
        |> Remoting.withErrorHandler (Remoting.errorHandler logger)
        |> Remoting.buildHttpHandler

    Require.services<ILogger<_>> remoting
