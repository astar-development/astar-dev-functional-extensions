using AStar.Dev.Functional.Extensions;

namespace AStar.Dev.SampleBlazor.Components.Pages;

public class UsernameService
{
    protected UsernameService()
    {
    }

    public static Task<Option<string>> TryValidateAsync(string input)
    {
        return Task.FromResult(string.IsNullOrWhiteSpace(input)
                                   ? Option.None<string>()
                                   : Option.Some(input.Trim()));
    }
}
