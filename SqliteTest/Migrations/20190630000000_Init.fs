namespace SqliteTest.Migrations

open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Migrations.Operations.Builders
open Microsoft.EntityFrameworkCore.Migrations.Operations
open Microsoft.EntityFrameworkCore
open System
open SqliteTest.UserContext
open Microsoft.EntityFrameworkCore.Infrastructure

type UserTable = 
    { UserID     : OperationBuilder<AddColumnOperation>
      PhoneNumber: OperationBuilder<AddColumnOperation> }

[<DbContext(typeof<UsersContext>)>]
[<Migration("20161006200628_Init")>]   
type Init () =
    inherit Migration ()

    override __.Up (migrationBuilder:MigrationBuilder) =
        migrationBuilder.CreateTable(
            name = "Users", 
            columns = (fun table -> 
                { UserID      = table.Column<string>(nullable = true)
                  PhoneNumber = table.Column<string>(nullable = true) }) ) |> ignore

    override __.BuildTargetModel(modelBuilder: ModelBuilder) =
        modelBuilder.Entity("SqliteTest.Tables.User", 
            fun b ->
                b.Property<Guid>("UserID").ValueGeneratedOnAdd() |> ignore
                b.Property<string>("PhoneNumber") |> ignore )
                |> ignore