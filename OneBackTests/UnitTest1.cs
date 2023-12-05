
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
        var score = _tennisGame.GetScore();
        Assert.AreEqual("love all", score);
    }
    [Test]
    public void fifteen_love()
    {
        GivenFirstPlayerScoreTimes(1);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("fifteen love", score);
    }

    [Test]
    public void thirty_love()
    {
        GivenFirstPlayerScoreTimes(2);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("thirty love", score);
    }

    [Test]
    public void forty_love()
    {
        GivenFirstPlayerScoreTimes(3);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("forty love", score);
    }
    [Test]
    public void love_fifteen()
    {
        GivenSecondPlayerScoreTimes(1);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("love fifteen", score);
    }
    [Test]
    public void duece()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(3);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("deuce", score);
    }
    [Test]
    public void first_player_adv()
    {
        GivenFirstPlayerScoreTimes(4);
        GivenSecondPlayerScoreTimes(3);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("Eva adv", score);
    }
    [Test]
    public void second_player_adv()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(4);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("Eric adv", score);
    }
    [Test]
    public void first_player_win()
    {
        GivenFirstPlayerScoreTimes(7);
        GivenSecondPlayerScoreTimes(5);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("Eva win", score);
    }
    [Test]
    public void second_player_win()
    {
        GivenFirstPlayerScoreTimes(3);
        GivenSecondPlayerScoreTimes(5);
        var score = _tennisGame.GetScore();
        Assert.AreEqual("Eric win", score);
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
                    if (_firstPlayerScore > _secondPlayerScore)
                    {
                        return $"{_firstName} adv";
                    }
                    else
                    {
                        return $"{_secondName} adv";
                    }
                }
                else
                {
                    if (_firstPlayerScore > _secondPlayerScore)
                    {
                        return $"{_firstName} win";
                    }
                    else
                    {
                        return $"{_secondName} win";
                    }
                }
            }

            return $"{TennisScore[_firstPlayerScore]} {TennisScore[_secondPlayerScore]}";
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
