// 1. Define discriminated union for Genre
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// 2. Define Director record type
type Director = {
    Name: string
    Movies: int
}

// 3. Define Movie record type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    ImdbRating: float
}

// 4. Create movie instances
let movies = [
    { Name = "The Power of the Dog"; RunLength = 126; Genre = Drama; 
      Director = { Name = "Jane Campion"; Movies = 10 }; ImdbRating = 6.8 }
    { Name = "Dune"; RunLength = 155; Genre = Fantasy;
      Director = { Name = "Denis Villeneuve"; Movies = 20 }; ImdbRating = 8.0 }
    { Name = "King Richard"; RunLength = 144; Genre = Sport;
      Director = { Name = "Reinaldo Marcus Green"; Movies = 5 }; ImdbRating = 7.5 }
    { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller;
      Director = { Name = "Guillermo del Toro"; Movies = 15 }; ImdbRating = 7.1 }
    { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy;
      Director = { Name = "Paul Thomas Anderson"; Movies = 12 }; ImdbRating = 7.4 }
]

// 5. Filter probable Oscar winners (IMDB > 7.4)
let probableOscarWinners = 
    movies 
    |> List.filter (fun movie -> movie.ImdbRating > 7.4)

// 6. Convert runtime to hours/minutes format
let convertRuntime (minutes: int) =
    $"{minutes / 60}h {minutes % 60}min"

let formattedRuntimes = 
    movies 
    |> List.map (fun movie -> convertRuntime movie.RunLength)

// Print results
printfn "Probable Oscar Winners:"
probableOscarWinners |> List.iter (fun m -> printfn "- %s (%.1f)" m.Name m.ImdbRating)

printfn "\nFormatted Runtimes:"
formattedRuntimes |> List.iter (printfn "- %s")
