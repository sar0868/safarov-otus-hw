using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class Enemy : MonoBehaviour
    {
        public void ReactToHit()
        {
            StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            transform.Rotate(-90f, 0f, 0f);
            yield return new WaitForSeconds(1f);

            Destroy(gameObject);
        }
    }
}
