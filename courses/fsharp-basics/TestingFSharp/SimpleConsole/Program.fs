module SimpleConsole.Program

printfn "Hello World!"

// let buildUrl (protocol: string) (baseUrl: string) (path: string) : string = $"{protocol}://{baseUrl}/{path}"
// let myWebsite = buildUrl "https" "bahrami85.ir" ""
// printfn $"{myWebsite}"

// let ages = (1,2)
// let (myAge, yourAge) = ages
// printfn $"I'm {myAge} but you're {yourAge}"

// type Project =
//     {
//       ProjectName: string
//       Stars: int }
//     member _.GetCodeOwner (): string = "dotnet"
//     member this.GetUrl (): string =
//         $"https://github.com/{this.ProjectName}"
//
// let fsharp: Project =
//     { ProjectName = "dotnet/fsharp"
//       Stars = 2800 }
//
// printfn $"Visit us at: {fsharp.GetUrl()}"

// type StringGitHubProject =
//     { ProjectName: string
//       Stars: int
//       State: string }
//
// let fakeProject: StringGitHubProject =
//     { ProjectName = "Amazing Project"
//       Stars = 0
//       State = "something" }
//
// type ProjectState =
//     | Archived
//     | Active of {| Maintainer: string |}
//
// type GitHubProject =
//     { ProjectName: string
//       Stars: int
//       State: ProjectState }
//
// let bootCodeMvpProject: GitHubProject =
//     { ProjectName = "BootCode MVP"
//       Stars = 0
//       State = Active {| Maintainer = "ME!" |} }

