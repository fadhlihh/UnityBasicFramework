using UnityEngine;
using Framework.FSM;

namespace StateMachineExample
{
    [CreateAssetMenu(fileName = "SeedState", menuName = "Apple/SeedState", order = 0)]
    public class SeedState : State
    {
        [SerializeField]
        private float _duration = 5;
        private float _timer = 5;
        public override void OnBeginState(StateMachineController controller)
        {
            _timer = _duration;
            Debug.Log("Start Plant Tree");
        }

        public override void OnExitState(StateMachineController controller)
        {
            Debug.Log("Stop Seed");
        }

        public override void OnUpdateState(StateMachineController controller)
        {
            if (_timer < 0)
            {
                AppleController appleController = (AppleController)controller;
                controller.SwitchScene(appleController.GrowingState);
            }
            else
            {
                _timer -= 1 * Time.deltaTime;
                Debug.Log("Seeded Soil");
            }
        }
    }
}
