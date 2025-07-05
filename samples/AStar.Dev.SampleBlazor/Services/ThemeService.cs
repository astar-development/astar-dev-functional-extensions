using Microsoft.JSInterop;

namespace AStar.Dev.SampleBlazor.Services;

public class ThemeService(IJSRuntime js)
{
    public           bool       IsDarkMode { get; private set; }

    public event Action? OnChange;

    public async Task InitializeAsync()
    {
        IsDarkMode = await js.InvokeAsync<bool>("theme.getPreference");
        OnChange?.Invoke();
    }

    public async Task ToggleAsync()
    {
        IsDarkMode = !IsDarkMode;
        await js.InvokeVoidAsync("theme.setPreference", IsDarkMode);
        OnChange?.Invoke();
    }
}
