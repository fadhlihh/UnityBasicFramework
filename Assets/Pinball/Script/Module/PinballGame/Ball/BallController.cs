using UnityEngine;
using Framework.Entity;
using Pinball.Messages;
using Pinball.Scene;
using Pinball.Module.Gameplay;

namespace Pinball.Module.Ball
{
    public class BallController : Controller<Data>
    {
        private Rigidbody _rigidbody;
        private GameplayController _gameplay;

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            _gameplay = PinballGameLauncher.Instance.Gameplay;
        }

        protected override void RegisterMessage()
        {
            base.RegisterMessage();
            Subscribe<PushBallMessage>(AddForce);
            Subscribe<MultiplyBallSpeedMessage>(MultiplyVelocity);
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            StartListening("RespawnBall", RespawnBall);
        }

        private void Update()
        {
            CheckBallPosition();
        }

        private void AddForce(PushBallMessage message)
        {
            _rigidbody.AddForce(message.Velocity);
        }

        private void MultiplyVelocity(MultiplyBallSpeedMessage message)
        {
            _rigidbody.velocity *= message.Multiplier;
        }

        private void CheckBallPosition()
        {
            if (transform.position.z < -11)
            {
                RespawnBall();
            }
        }

        private void RespawnBall()
        {
            transform.position = _gameplay.Data.Position;
        }
    }
}
