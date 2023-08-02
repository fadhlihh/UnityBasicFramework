using UnityEngine;
using TMPro;

namespace TweeningTest
{
    public class TweenManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private Color _color;

        private void Start()
        {
            LeanTween.value(_text.gameObject, OnUpdateValue, _text.color, _color, 3f).setOnComplete(() => Debug.Log("Complete")).setLoopPingPong();
        }

        private void OnUpdateValue(Color value)
        {
            _text.color = value;
        }
    }
}
