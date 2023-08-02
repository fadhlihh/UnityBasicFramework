using Framework.Entity;

namespace Pinball.Module.Coin
{
    public class CoinData : Data
    {
        public float Lifespan { get; set; } = 10f;
        public float Countdown { get; set; }
        public float RotationSpeed { get; set; } = 100f;
    }
}
