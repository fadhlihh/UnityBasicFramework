using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Bumper
{
    public class BumperController : Controller<BumperData>
    {
        [SerializeField]
        private List<Color> _colors = new List<Color>();

        private Renderer _renderer;

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            _renderer = GetComponent<Renderer>();
        }

        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Ball"))
            {
                ChangeColor();
                SendMessage<MultiplyBallSpeedMessage>(new MultiplyBallSpeedMessage(_data.Multiplier));
            }
        }

        private void ChangeColor()
        {
            _data.ColorIndex = ((_data.ColorIndex + 1) < _colors.Count) ? _data.ColorIndex + 1 : 0;
            _renderer.material.color = _colors[_data.ColorIndex];
        }
    }
}
