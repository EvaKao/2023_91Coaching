
namespace OneBackTests;

public class Tests
{
    private TennisGame _tennisGame  = null;

    [SetUp]
    public void SetUp()
    {
        _tennisGame = new TennisGame("Eva", "Eric");
    }
    
    [Test]
    public void love_all()
    {
        ShouldToBe("love all");
    }
    [Test]
    public void fifteen_love()
    {
        GivenFirstPlayerScoreTimes(1);
        ShouldToBe("fifteen love");
    }

    [Test]
    public void thirty_love()
    {
        GivenFirstPlayerScoreTimes(2);
        ShouldToBe("thirty love");
    }

    [Test]
    public void forty_love()
    {
        GivenFirstPlayerScoreTimes(3);
        ShouldToBe("forty love");
    }
    [Test]
    public void love_fifteen()
    {
        GivenSecondPlayerScoreTimes(1);
        ShouldToBe("love fifteen");
    }
    [Test]
    public void duece()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(3);
        ShouldToBe("deuce");
    }
    [Test]
    public void first_player_adv()
    {
        GivenFirstPlayerScoreTimes(4);
        GivenSecondPlayerScoreTimes(3);
        ShouldToBe("Eva adv");
    }
    [Test]
    public void second_player_adv()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(4);
        ShouldToBe("Eric adv");
    }
    [Test]
    public void first_player_win()
    {
        GivenFirstPlayerScoreTimes(7);
        GivenSecondPlayerScoreTimes(5);
        ShouldToBe("Eva win");
    }
    [Test]
    public void second_player_win()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(5);
        ShouldToBe("Eric win");
    }

    private void ShouldToBe(string excepted)
    {
        var score = _tennisGame.GetScore();
        Assert.AreEqual(excepted, score);
    }

    private void GivenFirstPlayerScoreTimes(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisGame.FirtsPlayerGetScore();
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

public class TennisGame
{
    private Dictionary<int, string> TennisScore = new Dictionary<int, string>()
    {
        {0, "love"}, {1, "fifteen"}, {2, "thirty"}, {3, "forty"}
    };
    private readonly string _firstName;
    private readonly string _secondName;
    private int _firstPlayerScore;
    private int _secondPlayerScore;

    public TennisGame(string firstName, string secondName)
    {
        _firstName = firstName;
        _secondName = secondName;
    }

    public string GetScore()
    {
        
        if (_firstPlayerScore == _secondPlayerScore)
        {
            if (_firstPlayerScore >= 3)
            {
                return $"deuce";
            }
            return $"{TennisScore[_firstPlayerScore]} all";
        }
        else
        {
            if (_firstPlayerScore > 3 || _secondPlayerScore > 3)
            {
                if (Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1)
                {
                    return GetScoreResult("adv");
                }
                else
                {
                    return GetScoreResult("win");
                }
            }

            return $"{TennisScore[_firstPlayerScore]} {TennisScore[_secondPlayerScore]}";
        }
    }

    private string GetScoreResult(string result)
    {
        if (_firstPlayerScore > _secondPlayerScore)
        {
            return $"{_firstName} {result}";
        }
        else
        {
            return $"{_secondName} {result}";
        }
    }

    public void FirtsPlayerGetScore()
    {
        _firstPlayerScore += 1;
    }

    public void SecondPlayerGetScore()
    {
        _secondPlayerScore += 1;
    }

}
