namespace Pinball.Messages
{
    public struct MultiplyBallSpeedMessage
    {
        public float Multiplier { get; set; }
        public MultiplyBallSpeedMessage(float multiplier)
        {
            Multiplier = multiplier;
        }
    }
}
