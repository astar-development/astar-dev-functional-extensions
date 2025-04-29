using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(OptionExtensions))]
public class OptionExtensionsShould
{
    [Fact]
    public void MapTheSomeObjectToTheNewSomeObject()
    {
        var obj = new Some<MockClass>(new  ());

        var result = obj.Map(mockClass => new MockClass2 { SomeText = mockClass.SomeText });

        result.ShouldBeAssignableTo<Some<MockClass2>>();
    }

    [Fact]
    public void MapTheNoneObjectToTheNewNone()
    {
        var obj = new None<MockClass>();

        var result = obj.Map(mockClass => new MockClass2 { SomeText = mockClass.SomeText });

        result.ShouldBeAssignableTo<None<MockClass2>>();
    }

    [Fact]
    public void FilterTheSomeOptionBasedOnThePredicate()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 }.Optional();

        var result = list.Filter(item => item.Contains(1));

        result.ShouldBeAssignableTo<Some<List<int>>>();
    }

    [Fact]
    public void FilterTheSomeOptionBasedOnThePredicateToNone()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 }.Optional();

        var result = list.Filter(item => item.Contains(1234));

        result.ShouldBeAssignableTo<None<List<int>>>();
    }

    [Fact]
    public void ReduceTheSomeContentToContainingType()
    {
        var obj = new Some<MockClass>(new  () { SomeText = "SomeText" });

        var result = obj.Reduce(new MockClass { SomeText = "SubstituteSomeText" });

        result.SomeText.ShouldBe("SomeText");
    }

    [Fact]
    public void ReduceTheSomeContentToContainingTypeUsingTheSubstituteObject()
    {
        var obj = new None<MockClass>();

        var result = obj.Reduce(new MockClass { SomeText = "SubstituteSomeText" });

        result.SomeText.ShouldBe("SubstituteSomeText");
    }

    [Fact]
    public void ReduceTheSomeContentToTheContainingType()
    {
        var obj = new Some<MockClass>(new  () { SomeText = "SomeText" });

        var result = obj.Reduce(MockClass.Create);

        result.SomeText.ShouldBe("SomeText");
    }

    [Fact]
    public void ReduceTheSomeContentToContainingTypeUsingTheSubstituteFunction()
    {
        var obj = new None<MockClass>();

        var result = obj.Reduce(MockClass.Create);

        result.SomeText.ShouldBe("MockClassCreate");
    }
}
