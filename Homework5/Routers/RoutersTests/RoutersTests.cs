namespace RoutersTests;

using Routers;

public class RoutersTests
{
    [Test]
    public void BuilderWithFirstCorrectTopologyShouldReturnRightMaximumSpeedTopology()
    {
        var input = """
        1: 2 (10), 3 (5)
        2: 3 (1)
        """.Replace("\r", "");

        var expected = "1: 2 (10), 3 (5)";
        Assert.That(TopologyBuilder.FindMaximumSpeedTopology(input), Is.EqualTo(expected));
    }

    [Test]
    public void BuilderWithSecondCorrectTopologyShouldReturnRightMaximumSpeedTopology()
    {
        var input = """
        1: 2 (13), 3 (18), 4 (17), 5 (14), 6 (22)
        2: 3 (26), 5 (19)
        3: 4 (30)
        4: 6 (22)
        """.Replace("\r", "");

        var expected = """
        1: 6 (22)
        2: 3 (26), 5 (19)
        3: 4 (30)
        4: 6 (22)
        """.Replace("\r", "");
        Assert.That(TopologyBuilder.FindMaximumSpeedTopology(input), Is.EqualTo(expected));
    }

    [Test]
    public void BuilderWithDisconnectedTopologyShouldThrowException()
    {
        var input = """
        1: 2 (10), 3 (5)
        4: 5 (6)
        """.Replace("\r", "");

        Assert.Throws<ArgumentException>(() => TopologyBuilder.FindMaximumSpeedTopology(input));
    }

    [Test]
    public void BuilderWithIncorrectTopologyShouldThrowException()
    {
        var input = """
        1: b (10), 3 (5)
        2: 3 (a)
        """.Replace("\r", "");

        Assert.Throws<ArgumentException>(() => TopologyBuilder.FindMaximumSpeedTopology(input));
    }

    [Test]
    public void BuilderWithEmptyTopologyShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => TopologyBuilder.FindMaximumSpeedTopology(string.Empty));
    }

    [Test]
    public void BuilderWithNullTopologyShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => TopologyBuilder.FindMaximumSpeedTopology(null));
    }
}