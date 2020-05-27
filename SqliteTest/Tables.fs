namespace SqliteTest.Tables

open System

type [<CLIMutable>] User =
    { UserID        : Guid
      PhoneNumber   : string
      FirstName     : string
      Surname       : string
      Email         : string
      Password      : string
      UserToken     : Guid
      Events        : int } //TODO: figure out this thing

//type User =
//    { UserID        : UserID
//      PhoneNumber   : string 
//      Name          : Name
//      Email         : string
//      Password      : string
//      UserToken     : UserToken
//      Events        : StreamID Set
//      AvailableTime : DateTime list 
//      CommittedTime : DateTime list }

//type UserStream = List<User>