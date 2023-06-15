using UnityEngine;
using Framework.Entity;

namespace Pinball.Module.Paddle
{
    public class PaddleController : Controller
    {
        [SerializeField]
        private KeyCode _paddleKey;
        [SerializeField]
        private KeyCode _altPaddleKey;

        private HingeJoint _joint;

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            _joint = GetComponent<HingeJoint>();
        }

        private void Update()
        {
            ReadInput();
        }

        public void ReadInput()
        {
            JointSpring spring = _joint.spring;
            if (Input.GetKey(_paddleKey) || Input.GetKey(_altPaddleKey))
            {
                spring.targetPosition = _joint.limits.max;
            }
            else
            {
                spring.targetPosition = _joint.limits.min;
            }
            _joint.spring = spring;
        }
    }
}
