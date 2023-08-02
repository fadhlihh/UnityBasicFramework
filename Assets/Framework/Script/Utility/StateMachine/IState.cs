using UnityEngine;

namespace Framework.FSM
{
    public abstract class State : ScriptableObject
    {
        public abstract void OnBeginState(StateMachineController controller);
        public abstract void OnUpdateState(StateMachineController controller);
        public abstract void OnExitState(StateMachineController controller);
    }
}
