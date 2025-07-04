using AStar.Dev.Functional.Extensions;

namespace AStar.Dev.SampleBlazor.Components.Pages;

public class UsernameService
{
    public Task<Option<string>> TryValidateAsync(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Task.FromResult(Option.None<string>());

        return Task.FromResult(Option.Some(input.Trim()));
    }
}
