using JetBrains.Annotations;

namespace AStar.Dev.Functional.Extensions;

[TestSubject(typeof(Result<,>))]
public class ResultShould
{
    [Fact]
    public void BeOfTypeStruct() => typeof(Result<,>).IsValueType.ShouldBeTrue();

    [Fact]
    public void BeImmutable() => typeof(Result<,>)?.DeclaringType?.Name.ShouldBe("sdsds");

    [Fact]
    public void ContainTwoGenericClassParameters()
    {
        var result = typeof(Result<,>).GetGenericArguments();

        result.Length.ShouldBe(2);
    }

    [Fact]
    public void ContainTheIsSuccessFlagSetToFalseByDefault()
        => new Result<string, string>().IsSuccess.ShouldBeFalse();

    [Fact]
    public void ContainTheIsFailureFlagSetToTrueByDefault()
        => new Result<string, string>().IsFailure.ShouldBeTrue();

    [Fact]
    public void CreateSuccessResult()
    {
        var result = Result<string, string>.Success("Some value here");

        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBe("Some value here");
    }

    [Fact]
    public void CreateFailureResult()
    {
        var result = Result<string, string>.Failure("Some value here");

        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    [Fact]
    public void CreateImplicitSuccessResult()
    {
        var result = ImplicitResult(false);

        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBe("Some value here");
    }

    [Fact]
    public void CreateImplicitFailureResult()
    {
        var result = ImplicitResult(true);

        result.IsSuccess.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    private static Result<int, string> ImplicitResult(bool fail)
    {
        if (!fail)
        {
            return "Some value here";
        }

        return -1;
    }
}
