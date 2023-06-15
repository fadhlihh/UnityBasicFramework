using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Launcher
{
    public class LauncherController : Controller<LauncherData>
    {
        [SerializeField]
        private KeyCode _launcherKey;

        private void Update()
        {
            ReadInput();
        }

        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Ball"))
            {
                _data.IsBallOnLauncher = true;
            }
        }

        private void OnCollisionExit(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Ball"))
            {
                _data.IsBallOnLauncher = false;
            }
        }

        private void ReadInput()
        {
            if (_data.IsBallOnLauncher)
            {
                if (Input.GetKey(_launcherKey) && _data.LauncherForce < _data.MaxLauncherForce)
                {
                    _data.LauncherForce += 500 * Time.deltaTime;
                }
                if (Input.GetKeyUp(_launcherKey))
                {
                    Vector3 velocity = Vector3.forward * _data.LauncherForce;
                    SendMessage<PushBallMessage>(new PushBallMessage(velocity));
                    _data.LauncherForce = 0f;
                }
            }
        }
    }
}
