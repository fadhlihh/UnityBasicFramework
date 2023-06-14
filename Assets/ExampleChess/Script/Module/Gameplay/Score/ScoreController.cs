using UnityEngine;
using TMPro;
using Framework.Entity;
using Example.Messages;

namespace Example.Module.Score
{
    public class ScoreController : Controller<ScoreData, IScoreData>
    {
        [SerializeField]
        private TMP_Text _scoreText;

        protected override void RegisterMessage()
        {
            base.RegisterMessage();
            Subscribe<AddScoreMessage>(AddScore);
        }

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            UpdateScoreText();
        }

        private void AddScore(AddScoreMessage message)
        {
            _data.Score += message.Score;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _data.Score.ToString();
        }

        private void OnDestroy()
        {
            Unsubscribe<AddScoreMessage>(AddScore);
        }
    }
}
