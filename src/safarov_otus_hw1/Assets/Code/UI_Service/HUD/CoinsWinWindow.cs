using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public sealed class CoinsWinWindow : MonoBehaviour
    {
        [SerializeField] private float _fallDuration = 2.0f;
        [SerializeField] private float _targetY = 125.0f;
        [SerializeField] private TextMeshProUGUI _text;

        private Sequence _sequence;

        private void Start()
        {
            _text.alpha = 0;
        }

        public void FallResult(int count)
        {
            _text.text = $"{count}";

            _sequence?.Kill();
            _sequence = null;
            _sequence = DOTween.Sequence();
            _sequence
            .Append(transform.DOMoveY(_targetY, _fallDuration))
            .SetEase(Ease.InQuad)
            .AppendInterval(0.5f)
            .Append(_text.DOFade(1f, 0.2f));
        }

    }
}
