using UnityEngine;

namespace Pinball.Messages
{
    public struct DestroyTrapMessage
    {
        public GameObject Trap { get; set; }
        public DestroyTrapMessage(GameObject trap)
        {
            Trap = trap;
        }
    }
}
