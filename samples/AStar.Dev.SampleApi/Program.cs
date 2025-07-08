using AStar.Dev.Functional.Extensions;

var app = WebApplication.Create();
app.MapGet("/", () => "Sample API up and running!");

app.MapGet("/greet", (string? name) =>
                     {
#pragma warning disable CS8604 // Possible null reference argument. That is the point...
                         Option<string> maybeName = name;
#pragma warning restore CS8604 // Possible null reference argument.

                         return maybeName.Match(
                                                some => $"Hello, {some} 👋",
                                                ()    => "Hello, anonymous 👻");
                     });

app.MapGet("/divide", (int a, int b) =>
                      {
                          Result<int, string> result = b == 0
                                                           ? new Result<int, string>.Error("Division by zero")
                                                           : new Result<int, string>.Ok(a / b);

                          return result.Match(
                                              ok => Results.Ok(new { Result         = ok }),
                                              err => Results.BadRequest(new { Error = err }));
                      });

app.MapGet("/parse", (string input) =>
                     {
                         var parsed = Try<int>.Run(() => int.Parse(input));

                         return parsed.Match(
                                             ok => Results.Ok(new { Parsed        = ok }),
                                             ex => Results.BadRequest(new { Error = ex.Message }));
                     });

await app.RunAsync();
