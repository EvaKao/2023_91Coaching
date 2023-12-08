using OneBackComboTrainingWeb.Domains.Soccer;

namespace OneBackTests
{
    public class SoccerMatchResultTests
    {
        private int _matchId = 123;
        private SoccerGameService _soccerGameService = null;
        private SoccerRepo _soccerRepo = null;

        [SetUp]
        public void SetUp()
        {
            _soccerRepo = new SoccerRepo();
            _soccerGameService = new SoccerGameService(_soccerRepo);
        }

        [Test(Description = "home get first goal")]
        public void home_goal()
        {
            MatchResultHomeGoalShouldBe("1:0(First Half)");
        }

        [Test(Description = "home get second goal")]
        public void home_second_goal()
        {
            GivenMatchResult(_matchId, "H");
            MatchResultHomeGoalShouldBe("2:0(First Half)");
        }

        [Test(Description = "home cancel second goal")]
        public void home_cancel_second_goal()
        {
            GivenMatchResult(_matchId, "HH");
            MatchResultHomeCancelShouldBe("1:0(First Half)");
        }

        [Test(Description = "away get first goal")]
        public void away_get_first_goal()
        {
            GivenMatchResult(_matchId, "H");
            MatchResultAwayGoalShouldBe("1:1(First Half)");
        }

        [Test(Description = "next period")]
        public void next_period()
        {
            GivenMatchResult(_matchId, "HA");
            MatchResultNextPeriodShouldBe("1:1(Second Half)");
        }

        [Test(Description = "away cancel first half goal when second half")]
        public void away_cancel()
        {
            GivenMatchResult(_matchId, "HA;");
            MatchResultAwayCancelShouldBe("1:0(Second Half)");
        }

        private void MatchResultHomeGoalShouldBe(string expected)
        {
            Assert.AreEqual(expected, WhenHomeGoal());
        }

        private void MatchResultAwayGoalShouldBe(string expected)
        {
            Assert.AreEqual(expected, WhenAwayGoal());
        }

        private void MatchResultHomeCancelShouldBe(string expected)
        {
            Assert.AreEqual(expected, WhenHomeCancel());
        }

        private void MatchResultAwayCancelShouldBe(string expected)
        {
            Assert.AreEqual(expected, WhenAwayCancel());
        }

        private string WhenAwayCancel()
        {
            return _soccerGameService.UpdateMatchResult(_matchId, "AwayCancel");
        }

        private void MatchResultNextPeriodShouldBe(string expected)
        {
            Assert.AreEqual(expected, WhenNextPeriod());
        }

        private string WhenNextPeriod()
        {
            return _soccerGameService.UpdateMatchResult(_matchId, "NextPeriod");
        }

        private string WhenAwayGoal()
        {
            return _soccerGameService.UpdateMatchResult(_matchId, "AwayGoal");
        }

        private string WhenHomeGoal()
        {
            return _soccerGameService.UpdateMatchResult(_matchId, "HomeGoal");
        }

        private string WhenHomeCancel()
        {
            return _soccerGameService.UpdateMatchResult(_matchId, "HomeCancel");
        }

        private void GivenMatchResult(int matchId, string matchResult)
        {
            _soccerRepo.SetMatchResult(matchId, matchResult);
        }
    }
}