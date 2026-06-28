using UnityEngine;

namespace Code
{
    public sealed class CoinСollecting : MonoBehaviour
    {
        [SerializeField] private int _health = 100;

        private string _tagPlayer = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_tagPlayer))
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.PlayerBehaviour.AddHp(_health);
                gameObject.SetActive(false);
            }
        }
    }
}
