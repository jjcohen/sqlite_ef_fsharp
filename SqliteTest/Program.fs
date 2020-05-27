open SqliteTest.Tables
open SqliteTest.UserContext
open System
open Microsoft.EntityFrameworkCore
open System.Diagnostics

let initialise () =
    use context = new UsersContext()
    context.Database.Migrate()
    context.SaveChanges() |> ignore

let timedFunction (func:'a -> unit) arg =
    let stopwatch = new Stopwatch()
    stopwatch.Start()
    func arg
    stopwatch.Stop()
    printfn "add took : %i" stopwatch.ElapsedMilliseconds

let a user =
    use context = new UsersContext()
    context.Users.Add(user) |> ignore
    context.SaveChanges() |> ignore

let add user = timedFunction a user

let d userID =
    use context = new UsersContext()
    context.Users.Remove(context.Users.) |> ignore
    context.SaveChanges() |> ignore

//[<EntryPoint>]
//initialise ()

//add {UserID = Guid.NewGuid(); PhoneNumber = "12345"} |> ignore
//add {UserID = Guid.NewGuid(); PhoneNumber = "23456"} |> ignore
//add {UserID = Guid.NewGuid(); PhoneNumber = "34567"} |> ignore
//add {UserID = Guid.NewGuid(); PhoneNumber = "45678"} |> ignore

//Console.Read() |> ignore