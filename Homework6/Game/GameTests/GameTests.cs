namespace GameTests;

using Game;

public class Tests
{
    private Game? game;

    [TestCase("../../../testFiles/Map1.txt", "../../../testFiles/Map1Right.txt", "../../../testFiles/Map1Up.txt")]
    public void RightMoveToOpenSpace(string pathToMap, string pathToMapRight, string pathToMapUp)
    {
        game = new(pathToMap);

        var expectedMap = game.Map;

        game.OnRight(this, EventArgs.Empty);
        expectedMap = game.UnloadMap(pathToMapRight);
        var actualMap = game.Map;
        Assert.That(actualMap, Is.EqualTo(expectedMap));

        game.OnLeft(this, EventArgs.Empty);
        expectedMap = game.UnloadMap(pathToMap);
        actualMap = game.Map;
        Assert.That(actualMap, Is.EqualTo(expectedMap));

        game.OnUp(this, EventArgs.Empty);
        expectedMap = game.UnloadMap(pathToMapUp);
        actualMap = game.Map;
        Assert.That(actualMap, Is.EqualTo(expectedMap));

        game.OnDown(this, EventArgs.Empty);
        expectedMap = game.UnloadMap(pathToMap);
        actualMap = game.Map;
        Assert.That(actualMap, Is.EqualTo(expectedMap));
    }

    [TestCase("../../../testFiles/Map2.txt")]
    public void RightMoveToWall(string pathToMap)
    {
        game = new(pathToMap);

        var expectedMap = game.Map;

        game.OnRight(this, EventArgs.Empty);

        var actualMap = game.Map;

        Assert.That(actualMap, Is.EqualTo(expectedMap));
    }
}