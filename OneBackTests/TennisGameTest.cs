using OneBackComboTrainingWeb;

namespace OneBackTests;

public class Tests
{
    private TennisGame? _tennisGame = null;

    [SetUp]
    public void SetUp()
    {
        _tennisGame = new TennisGame("Eva", "Eric");
    }

    [Test]
    public void love_all()
    {
        ScoreShouldToBe("love all");
    }

    [Test]
    public void fifteen_love()
    {
        GivenFirstPlayerScoreTimes(1);
        ScoreShouldToBe("fifteen love");
    }

    [Test]
    public void thirty_love()
    {
        GivenFirstPlayerScoreTimes(2);
        ScoreShouldToBe("thirty love");
    }

    [Test]
    public void forty_love()
    {
        GivenFirstPlayerScoreTimes(3);
        ScoreShouldToBe("forty love");
    }

    [Test]
    public void love_fifteen()
    {
        GivenSecondPlayerScoreTimes(1);
        ScoreShouldToBe("love fifteen");
    }

    [Test]
    public void duece()
    {
        GivenDeuce();
        ScoreShouldToBe("deuce");
    }

    [Test]
    public void first_player_adv()
    {
        GivenDeuce();
        GivenFirstPlayerScoreTimes(1);
        ScoreShouldToBe("Eva adv");
    }

    [Test]
    public void second_player_adv()
    {
        GivenDeuce();
        GivenSecondPlayerScoreTimes(1);
        ScoreShouldToBe("Eric adv");
    }

    [Test]
    public void first_player_win()
    {
        GivenFirstPlayerScoreTimes(7);
        GivenSecondPlayerScoreTimes(5);
        ScoreShouldToBe("Eva win");
    }

    [Test]
    public void second_player_win()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(5);
        ScoreShouldToBe("Eric win");
    }

    private void ScoreShouldToBe(string excepted)
    {
        var score = _tennisGame.GetScore();
        Assert.AreEqual(excepted, score);
    }

    private void GivenDeuce()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(3);
    }

    private void GivenFirstPlayerScoreTimes(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.FirstPlayerGetScore();
        }
    }

    private void GivenSecondPlayerScoreTimes(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.SecondPlayerGetScore();
        }
    }
}