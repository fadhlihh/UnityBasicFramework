using UnityEngine;
using Framework.FSM;

namespace StateMachineExample
{
    [CreateAssetMenu(fileName = "GrowingState", menuName = "Apple/GrowingState", order = 1)]
    public class GrowingState : State
    {
        [SerializeField]
        private float _duration = 5;
        private float _timer = 5;
        public override void OnBeginState(StateMachineController controller)
        {
            _timer = _duration;
            Debug.Log("Tree Start Growing");
        }

        public override void OnExitState(StateMachineController controller)
        {
            Debug.Log("Tree Stop Growing");
        }

        public override void OnUpdateState(StateMachineController controller)
        {
            if (_timer < 0)
            {
                AppleController appleController = (AppleController)controller;
                controller.SwitchScene(appleController.RipeState);
            }
            else
            {
                _timer -= 1 * Time.deltaTime;
                Debug.Log("Tree");
            }
        }
    }
}
