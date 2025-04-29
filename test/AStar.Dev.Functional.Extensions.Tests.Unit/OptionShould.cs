using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(Option))]
public class OptionShould
{
    [Fact]
    public void ReturnTheSpecifiedObjectAsAnOptionalObject()
    {
        new MockClass().Optional().ShouldBeAssignableTo<Option<MockClass>>();
    }

    [Fact]
    public void ReturnTheSpecifiedObjectAsAnInstanceOfTheSomeClass()
    {
        new MockClass().Optional().ShouldBeAssignableTo<Some<MockClass>>();
    }
}
