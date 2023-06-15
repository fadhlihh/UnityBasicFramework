using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.LauncherExit
{
    public class LauncherExitController : Controller<LauncherExitData>
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Vector3 velocity = Vector3.left * _data.ExitForce;
                SendMessage<PushBallMessage>(new PushBallMessage(velocity));
            }
        }
    }
}
