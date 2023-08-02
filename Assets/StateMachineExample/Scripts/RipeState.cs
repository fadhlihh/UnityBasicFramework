using UnityEngine;
using Framework.FSM;

namespace StateMachineExample
{
    [CreateAssetMenu(fileName = "RipeState", menuName = "Apple/RipeState", order = 2)]
    public class RipeState : State
    {
        [SerializeField]
        private float _duration = 5;
        private float _timer = 5;
        public override void OnBeginState(StateMachineController controller)
        {
            _timer = _duration;
            Debug.Log("Fruit Start Ripe");
        }

        public override void OnExitState(StateMachineController controller)
        {
            Debug.Log("Stop Plant Tree");
        }

        public override void OnUpdateState(StateMachineController controller)
        {
            if (_timer < 0)
            {
                AppleController appleController = (AppleController)controller;
                controller.SwitchScene(appleController.WitheredState);
            }
            else
            {
                _timer -= 1 * Time.deltaTime;
                Debug.Log("Fruit ready to harvest");
            }
        }


    }
}
