using UnityEngine;

namespace Pinball.Messages
{
    public struct PushBallMessage
    {
        public Vector3 Velocity { get; set; }

        public PushBallMessage(Vector3 velocity)
        {
            Velocity = velocity;
        }
    }
}
