namespace OneBackComboTrainingWeb.Domains.Soccer;

public class SoccerRepo
{
    private string _matchResult = String.Empty;

    public SoccerRepo()
    {
    }

    public string GetMatchResult(int matchId)
    {
        return _matchResult;
    }

    public void SetMatchResult(int matchId, string matchResult)
    {
        _matchResult = matchResult;
    }
}