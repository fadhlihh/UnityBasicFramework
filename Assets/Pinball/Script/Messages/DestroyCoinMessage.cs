using UnityEngine;

namespace Pinball.Messages
{
    public struct DestroyCoinMessage
    {
        public GameObject Coin { get; set; }
        public DestroyCoinMessage(GameObject coin)
        {
            Coin = coin;
        }
    }
}
