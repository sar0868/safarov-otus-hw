using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class Attack : MonoBehaviour
    {
        [SerializeField] private NewInputService _inputService;
        // [SerializeField] private OldInputService _inputService;
        [SerializeField] private float _radius;
        [SerializeField] private int _countCharges;
        private Animator _animator;
        private int _layerMask;
        [SerializeField] private int _charges;
        private float _slashDelay;
        private float _chargeDistance = 5f;
        private float _slashDistance = 0.05f;
        private float _currentDistance;



        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputService.attackEvent.AddListener(Slash);
            _inputService.rechargeEvent.AddListener(Recharge);
            _layerMask = LayerMask.GetMask("Enemy");
            _currentDistance = _slashDistance;
        }

        public void Slash()
        {
            _animator.SetTrigger("Slash");
            StartCoroutine(HitEnemy());

        }

        public IEnumerator HitEnemy()
        {
            yield return new WaitForSeconds(0.5f);
            if (IsCharges())
            {
                _currentDistance = _chargeDistance;
                _charges--;

            }
            else
            {
                _currentDistance = _slashDistance;
            }
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, _radius, transform.forward, _currentDistance, _layerMask);
            if (hits != null)
            {
                foreach (RaycastHit hit in hits)
                {
                    Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.ReactToHit();
                    }
                }
            }
        }

        public void Recharge()
        {
            if (IsCharges())
            {
                return;
            }
            _charges = _countCharges;
        }

        private bool IsCharges()
        {
            return _charges > 0;
        }
    }
}

