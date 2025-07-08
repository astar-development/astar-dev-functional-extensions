using AStar.Dev.Functional.Extensions;
using Microsoft.AspNetCore.Components;

namespace AStar.Dev.SampleBlazor.Components.Pages;

public partial class OptionDemo : ComponentBase
{
    private bool   debugVisible   ;

    private PipelineLog pipelineSteps = new();
    private string      resultMessage = string.Empty;
    private string      userInput     = string.Empty;

    private async Task CheckUsernameAsync()
    {
        pipelineSteps = new()
                        {
                            Input     = userInput,
                            Timestamp = DateTime.Now
                        };

        var validated = await UsernameService.TryValidateAsync(userInput);

        pipelineSteps.Validated = validated;
        var mapped =  validated.Map(name => name.ToUpper());
        pipelineSteps.Mapped = mapped;

        var result =  mapped.Match(
                                   valid =>
                                   {
                                       pipelineSteps.BranchTaken  = "Some";
                                       pipelineSteps.FinalMessage = $"✅ Welcome, {valid}!";

                                       return pipelineSteps.FinalMessage;
                                   },
                                   () =>
                                   {
                                       pipelineSteps.BranchTaken  = "None";
                                       pipelineSteps.FinalMessage = "❌ Username is invalid.";

                                       return pipelineSteps.FinalMessage;
                                   });

        resultMessage = result;
    }

    private static bool IsWarning(Option<string>? opt)
    {
        return opt is not null && opt.IsNone();
    }

    private void ToggleDebug()
    {
        debugVisible = !debugVisible;
    }

    private sealed class PipelineLog
    {
        public string          Input        { get; set; } = "";
        public Option<string>? Validated    { get; set; }
        public Option<string>? Mapped       { get; set; }
        public string          BranchTaken  { get; set; } = "—";
        public string          FinalMessage { get; set; } = "—";
        public DateTime        Timestamp    { get; set; }
    }
}
