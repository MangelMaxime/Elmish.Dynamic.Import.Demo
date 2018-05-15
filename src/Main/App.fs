module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

type CounterState =
    | Loading
    // | Loaded of Counter.Model

type Model =
    { Value : string
      Counter : CounterState }

type Msg =
    | ChangeValue of string
    // | CounterMsg of Counter.Msg

let init _ = { Value = ""
               Counter = Loading }, Cmd.none

let private update msg model =
    match msg with
    | ChangeValue newValue ->
        { model with Value = newValue }, Cmd.none

    // | CounterMsg counterMsg ->
    //     match model.Counter with
    //     | Loading -> model, Cmd.none
    //     | Loaded counterModel ->
    //         let counterModel = Counter


let private view model dispatch =
    Hero.hero [ Hero.IsFullHeight ]
        [ Hero.body [ ]
            [ Container.container [ ]
                [ Columns.columns [ Columns.CustomClass "has-text-centered" ]
                    [ Column.column [ Column.Width(Screen.All, Column.IsOneThird)
                                      Column.Offset(Screen.All, Column.IsOneThird) ]
                        [ Image.image [ Image.Is128x128
                                        Image.Props [ Style [ Margin "auto"] ] ]
                            [ img [ Src "assets/fulma_logo.svg" ] ]
                          Field.div [ ]
                            [ Label.label [ ]
                                [ str "Enter your name" ]
                              Control.div [ ]
                                [ Input.text [ Input.OnChange (fun ev -> dispatch (ChangeValue ev.Value))
                                               Input.Value model.Value
                                               Input.Props [ AutoFocus true ] ] ] ]
                          Content.content [ ]
                            [ str "Hello, "
                              str model.Value
                              str " "
                              Icon.faIcon [ ]
                                [ Fa.icon Fa.I.SmileO ] ] ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
#if DEBUG
|> Program.withHMR
#endif
|> Program.withReactUnoptimized "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
