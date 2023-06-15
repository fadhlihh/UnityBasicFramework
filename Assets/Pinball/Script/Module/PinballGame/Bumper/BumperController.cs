using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Bumper
{
    public class BumperController : Controller<BumperData>
    {
        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Ball"))
            {
                Debug.Log("Boom");
                SendMessage<MultiplyBallSpeedMessage>(new MultiplyBallSpeedMessage(_data.Multiplier));
            }
        }
    }
}
