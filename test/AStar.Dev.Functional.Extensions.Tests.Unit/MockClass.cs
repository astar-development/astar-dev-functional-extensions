namespace AStar.Dev.Functional.Extensions;

internal sealed class MockClass
{
    public string SomeText { get; set; } = "SomeText";

    public static MockClass Create()
    {
        return new()  { SomeText = "MockClassCreate" };
    }
}

internal sealed class MockClass2
{
    public string SomeText { get; set; } = "SomeText";
}
