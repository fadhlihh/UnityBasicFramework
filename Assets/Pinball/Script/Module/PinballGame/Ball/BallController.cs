using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Ball
{
    public class BallController : Controller<Data>
    {
        private Rigidbody _rigidbody;

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void RegisterMessage()
        {
            base.RegisterMessage();
            Subscribe<PushBallMessage>(AddForce);
            Subscribe<MultiplyBallSpeedMessage>(MultiplyVelocity);
        }

        private void AddForce(PushBallMessage message)
        {
            _rigidbody.AddForce(message.Velocity);
        }

        private void MultiplyVelocity(MultiplyBallSpeedMessage message)
        {
            _rigidbody.velocity *= message.Multiplier;
        }
    }
}
