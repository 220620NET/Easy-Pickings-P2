# ORM
ORM stands for object relational mapper, and its a technology that abstracts away from having to write specific sql statements
ORM's help with translating between a programming language and a DB language

Entity Framework Core is the ORM for .NET Core, and it uses ADO.NET under the hood, but presents even more streamlined interface.

## Two Different Approaches
### DB First (aka Reverse Engineering)
We take the pre-existing db, and let EF core read the schema of the db and create C# objects out of it
We _scaffold_ the tables into our C# objects

### Code First
We take the existing C# model objects and let EF Core create tables from it
We reflect the changes in our C# model to our db through _migrations_
