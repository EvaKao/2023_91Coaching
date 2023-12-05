namespace OneBackComboTrainingWeb;

public class TennisGame
{
    private readonly string _firstName;
    private readonly string _secondName;
    private int _firstPlayerScore;
    private int _secondPlayerScore;

    private readonly Dictionary<int, string> _tennisScoreMapping = new()
    {
        { 0, "love" },
        { 1, "fifteen" },
        { 2, "thirty" },
        { 3, "forty" }
    };

    public TennisGame(string firstName, string secondName)
    {
        _firstName = firstName;
        _secondName = secondName;
    }

    public string GetScore()
    {
        if (IsSameScore())
        {
            if (_firstPlayerScore >= 3)
            {
                return "deuce";
            }
            return AllScore();
        }
        if (_firstPlayerScore <= 3 && _secondPlayerScore <= 3)
        {
            return LookupScore();
        }
        if (IsAdv())
        {
            return GetPlayerScoreResult("adv");
        }
        return GetPlayerScoreResult("win");
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
    }

    private string LookupScore()
    {
        return $"{_tennisScoreMapping[_firstPlayerScore]} {_tennisScoreMapping[_secondPlayerScore]}";
    }

    private string AllScore()
    {
        return $"{_tennisScoreMapping[_firstPlayerScore]} all";
    }

    private bool IsSameScore()
    {
        return _firstPlayerScore == _secondPlayerScore;
    }

    public void FirstPlayerGetScore()
    {
        _firstPlayerScore += 1;
    }

    public void SecondPlayerGetScore()
    {
        _secondPlayerScore += 1;
    }

    private string GetPlayerScoreResult(string result)
    {
        return _firstPlayerScore > _secondPlayerScore ? $"{_firstName} {result}" : $"{_secondName} {result}";
    }
}