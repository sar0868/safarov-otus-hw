using System;
using System.Collections;
using System.Data.Common;
using UnityEngine;

namespace Code
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float _health = 2.0f;
        [SerializeField] private float _lifeTime = 2.0f;

        private float _hp;
        private bool _isAlive = true;


        private void Start()
        {
            _hp = _health;
        }

        public bool CanTakeDamage(float damage)
        {
            if (_isAlive == false)
            {
                return false;
            }

            _health -= damage;
            if(_health <= 0)
            {
                StartCoroutine(Destruction());
                _isAlive = false;
                return false;
            }
            return true;
        }

        private IEnumerator Destruction()
        {
            var component = GetComponent<Renderer>();
            component.material.color = Color.red;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.yellow;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.purple;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.magenta;

            yield return new WaitForSeconds(_lifeTime);
            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            if (TryGetComponent<Renderer>(out Renderer renderer))
            {
                Color color = renderer.material.color;
                for (float alpha = 1.0f; alpha >= 0.0f; alpha -= 0.01f)
                {
                    color.a = alpha;
                    renderer.material.color = color;

                    yield return new WaitForSeconds(0.01f);
                }

                if (TryGetComponent<Collider>(out Collider collider))
                {
                    Destroy(collider);
                }
                yield return new WaitForSeconds(5.0f);

                Destroy(gameObject);            
            }
        }
    }
}


