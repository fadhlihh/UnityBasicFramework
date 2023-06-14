using Framework.Entity;

namespace Example.Module.Score
{
    public interface IScoreData : IData
    {
        public int Score { get; }
    }
}
