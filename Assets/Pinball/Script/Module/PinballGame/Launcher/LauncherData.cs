using Framework.Entity;

namespace Pinball.Module.Launcher
{
    public class LauncherData : Data
    {
        public bool IsBallOnLauncher { get; set; }
        public float LauncherForce { get; set; }
        public float MaxLauncherForce { get; set; } = 3000f;
    }
}
