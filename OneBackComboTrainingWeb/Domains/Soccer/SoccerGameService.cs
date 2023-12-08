using System.Linq;

namespace OneBackComboTrainingWeb.Domains.Soccer;

public class SoccerGameService
{
    private SoccerRepo _soccerRepo;

    public SoccerGameService(SoccerRepo soccerRepo)
    {
        _soccerRepo = soccerRepo;
    }

    public string UpdateMatchResult(int matchId, string soccerEvent)
    {
        var currentMatchResult = _soccerRepo.GetMatchResult(matchId);

        string newestMatchResult = soccerEvent switch
        {
            "NextPeriod" => currentMatchResult + ";",
            "AwayGoal" => currentMatchResult + "A",
            "HomeCancel" or "AwayCancel" => CancelGoal(currentMatchResult),
            "HomeGoal" => currentMatchResult + "H",
            _ => ""
        };
        _soccerRepo.SetMatchResult(matchId, newestMatchResult);

        var homeScore = newestMatchResult.Count(f => f == 'H');
        var awayScore = newestMatchResult.Count(f => f == 'A');
        var period = newestMatchResult.Contains(';') ? "Second Half" : "First Half";
        return $"{homeScore}:{awayScore}({period})";
    }

    private static string CancelGoal(string currentMatchResult)
    {
        if (currentMatchResult.Last()==';')
        {
            return currentMatchResult.Substring(0, currentMatchResult.Length - 2) + ";";
        }
        return currentMatchResult.Substring(0, currentMatchResult.Length - 1);
    }
}