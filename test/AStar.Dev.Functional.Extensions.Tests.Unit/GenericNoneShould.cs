using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(None<>))]
public class GenericNoneShould
{
    [Fact]
    public void OverrideToStringAsExpected()
    {
        None.Of<int>().ToString().ShouldBe("None");
    }
}
