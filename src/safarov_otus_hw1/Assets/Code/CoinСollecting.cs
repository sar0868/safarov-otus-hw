using UnityEngine;

namespace Code
{
    public sealed class CoinСollecting : MonoBehaviour
    {
        [SerializeField] private Conditions _conditions;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _conditions.AddCoun();
                gameObject.SetActive(false);
            }
        }
    }

}
