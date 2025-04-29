using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(None))]
public class NoneShould
{
    [Fact]
    public void ReturnNone()
    {
        None.Value.ShouldBeAssignableTo<None>();
    }

    [Fact]
    public void ReturnNoneOf()
    {
        None.Of<int>().ShouldBeAssignableTo<None<int>>();
    }
}
