# -flix

## Description ##
Welcom the #flix the movie watchlist in which you can share your list with your friends

## Tech Stack ##
* ASP.NET Core 3.1
* Entity Framework 6.2
* PostgreSQL
* C#
* HTML
* CSS
* Bootstrap
* JavaScript
* jQuery

## Workflow Process ##
Our was using Agile prinicipals discusses our production process for this challenge.

## How to Install and Use ##
1. Clone the repository
```
git clone https://github.com/JPprojects/flix
```
2.Direct to the project solutions
```
Open in visual studio
Open flix.sln
```
3. Set up your database using postgress db and .net ef 
```
Open terminal 
Run command createdb Flix
Run command dotnet ef database update UserTable
Run command dotnet ef database update AddedPlaylist1
Run command dotnet ef database update AddedWatchList
Run command dotnet ef database update ChangedTitleToMovie
Run command dotnet ef database update ChangedWLUIdtoPLid
Run command dotnet ef database update PosterPath
```
4.Safety checks
```
Check that you have all 3 table:
  .User
  .Playlists
  .Watchlist
Check they have all the right columns:
  .User:
      .Id
      .UserName
      .Email
      .FirstName
      .LastName
      .Password
   .Playlists:
      .Id
      .Title
      .UserId
   .Watchlist:
      .Id
      .MovieTitle
      .PlaylistId
      .PosterPath
```
5.Get #Flixing!
```
Run the application and enjoy!
```

## Contributors ##
* [Jerome Painter](https://github.com/JPprojects)
* [Chan Singh](https://github.com/Chanpreet24)
* [Glen Hani](https://github.com/GlenHani)
* [Ade Awolesi](https://github.com/Adewunmi12)
