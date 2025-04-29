using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(Some<>))]
public class SomeShould
{
    [Fact]
    public void ReturnTheExpectedStringContent()
    {
        var sut = new Some<string>("Test");

        sut.Content.ShouldBe("Test");
    }

    [Fact]
    public void ReturnTheExpectedMockClassContent()
    {
        var sut = new Some<MockClass>(new ());

        sut.Content.ShouldBeEquivalentTo(new MockClass());
    }

    [Fact]
    public void ReturnTheExpectedToStringForTheObjectType()
    {
        var sut = new Some<MockClass>(new ());

        sut.ToString().ShouldBe("AStar.Dev.Functional.Extensions.MockClass");
    }

    [Fact]
    public void ReturnTheExpectedToStringForTheNull()
    {
        var sut = new Some<MockClass>(null!);

        sut.ToString().ShouldBe("<null>");
    }
}
