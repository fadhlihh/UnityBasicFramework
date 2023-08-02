using UnityEngine;
using Framework.Entity;
using Pinball.Messages;

namespace Pinball.Module.Coin
{
    public class CoinController : Controller<CoinData>
    {
        public void InitObject()
        {
            _data.Countdown = _data.Lifespan;
        }

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            InitObject();
        }

        private void Update()
        {
            RotateCoin();
            CountLifeTime();
        }

        private void RotateCoin()
        {
            transform.Rotate(new Vector3(0, 0, _data.RotationSpeed * Time.deltaTime));
        }

        private void CountLifeTime()
        {
            if (_data.Countdown > 0)
            {
                _data.Countdown -= 1 * Time.deltaTime;
            }
            else
            {
                DestroyCoin();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                DestroyCoin();
            }
        }

        private void DestroyCoin()
        {
            SendMessage<DestroyCoinMessage>(new DestroyCoinMessage(gameObject));
        }
    }
}
