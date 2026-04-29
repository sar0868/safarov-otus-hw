using DG.Tweening;
using UnityEngine;

namespace Code
{
    public sealed class CoinsWinWindow : MonoBehaviour
    {
        [SerializeField] private float _fallDuration = 2.0f;
        [SerializeField] private float _targetY = 125.0f;

        public void FallCoins()
        {
            transform.DOMoveY(_targetY, _fallDuration)
            .SetEase(Ease.InQuad);
        }

    }
}
