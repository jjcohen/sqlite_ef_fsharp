namespace SqliteTest.UserContext

open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Storage.ValueConversion
open System
open SqliteTest.Tables

type UsersContext =
    inherit DbContext
    
    new() = { inherit DbContext() }
    new(options: DbContextOptions<UsersContext>) = { inherit DbContext(options) }

    override __.OnModelCreating modelBuilder = 
        let userIdConvert = ValueConverter<Guid, string>((fun v -> v.ToString()), (fun v -> Guid.Parse(v) ))
        modelBuilder.Entity<User>().Property(fun e -> e.UserID).HasConversion(userIdConvert) |> ignore
        modelBuilder.Entity<User>().ToTable("Users") |> ignore

    override __.OnConfiguring optionsBuilder =
        optionsBuilder.UseSqlite("""Data Source=UsersDB.db;""") |> ignore
    
    [<DefaultValue>]
    val mutable users:DbSet<User>
    member __.Users with get() = __.users and set user = __.users <- user