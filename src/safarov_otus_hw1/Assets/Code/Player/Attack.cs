using System;
using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class Attack : MonoBehaviour
    {
        public static event Action<int> OnChargesChanged;
        [SerializeField] private NewInputService _inputService;
        [SerializeField] private float _radius;
        [SerializeField] private int _countCharges;
        [SerializeField] private PlayerAnimation _playerAnimation;

        private Animator _animator;
        private int _layerMask;
        private int _charges;
        private float _slashDelay;
        private float _chargeDistance = 5f;
        private float _slashDistance = 0.05f;
        private float _currentDistance;

        public int Charges
        {
            get => _charges;
            set
            {
                _charges = value;
                OnChargesChanged?.Invoke(_charges);
            }

        }

        private void Awake()
        {
            _animator = _playerAnimation.GetComponent<Animator>();
            _inputService.attackEvent.AddListener(Slash);
            _inputService.rechargeEvent.AddListener(Recharge);
            _layerMask = LayerMask.GetMask("Enemy");
            _currentDistance = _slashDistance;

        }

        private void Start()
        {
            Charges = 0;
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
                Charges--;

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
            Charges = _countCharges;
        }

        private bool IsCharges()
        {
            return Charges > 0;
        }
    }
}

