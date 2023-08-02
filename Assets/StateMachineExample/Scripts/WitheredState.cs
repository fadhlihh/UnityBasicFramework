using UnityEngine;
using Framework.FSM;

namespace StateMachineExample
{
    [CreateAssetMenu(fileName = "WitheredState", menuName = "Apple/WitheredState", order = 3)]
    public class WitheredState : State
    {
        [SerializeField]
        private float _duration = 5;
        private float _timer = 5;
        public override void OnBeginState(StateMachineController controller)
        {
            _timer = _duration;
            Debug.Log("Three Start Whitered");
        }

        public override void OnExitState(StateMachineController controller)
        {
            Debug.Log("Three Died");
        }

        public override void OnUpdateState(StateMachineController controller)
        {
            if (_timer < 0)
            {
                AppleController appleController = (AppleController)controller;
                controller.SwitchScene(appleController.SeedState);
            }
            else
            {
                _timer -= 1 * Time.deltaTime;
                Debug.Log("Brown Tree");
            }
        }
    }
}
