using Framework.Entity;

namespace Example.Module.Score
{
    public class ScoreData : Data, IScoreData
    {
        public int Score { get; set; }
    }
}
