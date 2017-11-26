module App

open Elmish
open Elmish.React

open Fable.Helpers.React.Props
module R = Fable.Helpers.React

type Model = int

type Msg = Increment | Decrement

let init () = 0

let update msg (model : Model) =
  match msg with
  | Increment -> model + 1
  | Decrement -> model - 1

let view model dispatch =
  R.div []
      [ R.h1 [] [ R.str "SAFE Template" ]
        R.p  [] [ R.str "Press buttons to manipulate counter:" ]
        R.button [ OnClick (fun _ -> dispatch Decrement) ] [ R.str "-" ]
        R.div [] [ R.str (sprintf "%A" model) ]
        R.button [ OnClick (fun _ -> dispatch Increment) ] [ R.str "+" ] ]

//-:cnd:noEmit
#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkSimple init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
//+:cnd:noEmit
|> Program.run
