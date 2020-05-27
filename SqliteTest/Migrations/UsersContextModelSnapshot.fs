namespace SqliteTest.Migrations

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open SqliteTest.UserContext

[<DbContext(typeof<UsersContext>)>]
type UsersContextModelSnapshot() =
    inherit ModelSnapshot()
    override __.BuildModel(modelBuilder: ModelBuilder) =
        modelBuilder.Entity("MyAPI.Domain.WeatherEvent",
            fun b ->
                b.Property<Guid>("UserID").ValueGeneratedOnAdd() |> ignore
                b.Property<string>("PhoneNumber") |> ignore) |> ignore