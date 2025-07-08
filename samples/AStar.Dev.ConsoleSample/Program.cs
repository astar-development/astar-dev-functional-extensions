using AStar.Dev.Functional.Extensions;

Console.WriteLine("🔎 FunctionalResults Sample");

// Example: Option<T>
var maybeName = GetUserInput();

var greeting = maybeName.Match(
                               name => $"Hello, {name}!",
                               ()    => "Hello, mysterious stranger.");

Console.WriteLine(greeting);

// Example: Result<T, E>
var result = Divide(10, 0);

var message = result.Match(
                           val => $"Quotient: {val}",
                           err => $"Error: {err}");

Console.WriteLine(message);

// Example: Try<T>
var risky = Try<int>.Run(() => int.Parse("not-an-int"));

var parsed = risky.Match(
                         ok => $"Parsed int: {ok}",
                         ex => $"Caught exception: {ex.Message}");

Console.WriteLine(parsed);

var numbers = new List<int> { 1, 2, 3, 4, 5 };

var found    = numbers.FirstOrNone(n => n == 3);  // returns Option<int>.Some
var notFound = numbers.FirstOrNone(n => n == 10); // returns Option<int>.None

Console.WriteLine(found);    // Output: Some(3)
Console.WriteLine(notFound); // Output: None

var result2 = await TryFetchUsernameAsync()
                    .MapAsync(name => name.Trim())
                    .BindAsync(ValidateAsync)
                    .MatchAsync(
                                valid => Task.FromResult($"Welcome, {valid}!"),
                                () => Task.FromResult("No valid user found.")
                               );

Console.WriteLine(result2); // Output: Welcome, Jason!
Option.Some("Jason");
Option.None<string>();
var (isSome, value) = Option.Some("hello");
Console.WriteLine(isSome);
Console.WriteLine(value);

return;

Option<string> GetUserInput()
{
    Console.Write("Enter your name (or leave blank): ");
    var input = Console.ReadLine();

    return string.IsNullOrWhiteSpace(input) ? Option.None<string>() : input;
}

Result<int, string> Divide(int numerator, int denominator)
{
    return denominator == 0
               ? new Result<int, string>.Error("Division by zero")
               : new Result<int, string>.Ok(numerator / denominator);
}

static Task<Option<string>> TryFetchUsernameAsync()
{
    return Task.FromResult<Option<string>>(new Option<string>.Some(" Jason "));
}

static Task<Option<string>> ValidateAsync(string name)
{
    return Task.FromResult(name.Trim() == "Jason"
                               ? new Option<string>.Some(name.Trim())
                               : Option.None<string>());
}
