using Framework.Entity;

namespace Pinball.Module.Trap
{
    public class TrapData : Data
    {
        public float Lifespan { get; set; } = 10f;
        public float Countdown { get; set; }
    }
}
