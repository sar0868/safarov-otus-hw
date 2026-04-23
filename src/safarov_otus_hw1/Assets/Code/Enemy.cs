using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class Enemy : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        public void ReactToHit()
        {

            StartCoroutine(Die());
            // _animator.SetBool("Death", true);
        }

        private IEnumerator Die()
        {

            transform.Rotate(-90f, 0f, 0f);
            yield return new WaitForSeconds(1f);

            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }
}
