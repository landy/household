module Household.Client.App

open Feliz

ReactDOM
    .createRoot(Browser.Dom.document.getElementById ("safer-app"))
    .render (View.AppView())