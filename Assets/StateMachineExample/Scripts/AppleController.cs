using Framework.FSM;

namespace StateMachineExample
{
    public class AppleController : StateMachineController
    {
        public SeedState SeedState;
        public GrowingState GrowingState;
        public RipeState RipeState;
        public WitheredState WitheredState;
        protected override void InitStateMachine()
        {
            CurrentState = SeedState;
        }
    }
}
