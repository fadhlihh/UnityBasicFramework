namespace Example.Messages
{
    public struct AddScoreMessage
    {
        public int Score { get; set; }

        public AddScoreMessage(int score)
        {
            Score = score;
        }
    }
}
