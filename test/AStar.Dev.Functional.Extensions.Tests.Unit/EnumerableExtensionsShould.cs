using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(EnumerableExtensions))]
public class EnumerableExtensionsShould
{
    [Fact]
    public void ReturnTheExpectedFirstObject()
    {
        var list = new List<int> { 1, 2, 3 };

        list.FirstOrNone(i => i == 2).ShouldBeAssignableTo<Some<int>>();
    }

    [Fact]
    public void ReturnTheExpectedNoneObject()
    {
        var list = new List<int> { 1, 2, 3 };

        list.FirstOrNone(i => i > 3).ShouldBeAssignableTo<None<int>>();
    }
}
