module Counter

open Fable.Core
open Fable.Import
open Elmish
open Fable.PowerPack


type Model = int

type Msg =
| Increment
| Decrement

let private init() : Model = 0

let private update msg (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

open Fable.Helpers.React
open Fable.Helpers.React.Props

let private view model dispatch =

  div []
      [ button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
        div [] [ str (sprintf "%A" model) ]
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ] ]

type Exports =
    abstract Update: Msg * Model -> Model
    abstract Init: unit -> Model
    abstract View: (Msg -> unit) * Model -> React.ReactElement

[<ExportDefault>]
let private exports =
    { new Exports with
            member __.Update(msg, model) = update msg model
            member __.Init() = init ()
            member __.View(model, dispatch) = view dispatch model }
