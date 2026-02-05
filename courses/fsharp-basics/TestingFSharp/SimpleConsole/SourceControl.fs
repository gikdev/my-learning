module public SimpleConsole.SourceControl

type public Repo(name: string, stars: int) =
    // private props
    let baseUrl = "https://github.com/"

    // private methods
    let incStarsBy stars n = stars + n

    // additional ctors
    // new() = Repo("", 0)

    // instance props
    member this.Name: string = name // readonly
    member val Stars: int = stars with get, set // mutable

    // static methods
    static member PrintHelp() = "class that contains repo info"
    