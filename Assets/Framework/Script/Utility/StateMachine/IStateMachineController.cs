using Framework.Utility;

namespace Framework.FSM
{
    public abstract class StateMachineController : SingletonBehaviour<StateMachineController>
    {
        public State CurrentState { get; set; }

        public void SwitchScene(State nextState)
        {
            CurrentState?.OnExitState(this);
            CurrentState = nextState;
            CurrentState?.OnBeginState(this);
        }

        protected abstract void InitStateMachine();

        private void Start()
        {
            InitStateMachine();
            CurrentState?.OnBeginState(this);
        }

        private void Update()
        {
            CurrentState?.OnUpdateState(this);
        }
    }
}
