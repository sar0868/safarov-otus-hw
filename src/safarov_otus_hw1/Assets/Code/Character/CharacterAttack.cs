using System;
using Code.Enemies;
using Code.Service;
using UnityEngine;


namespace Code.Character
{
    public sealed class CharacterAttack : MonoBehaviour
    {
        public event Action<int> OnChangedCharges;
        [SerializeField] private InputService _inputService;
        [SerializeField] private Camera _camera;
        [SerializeField] private int _countCharges = 20;
        [SerializeField] private float _distanceAttack = 10.0f;
        [SerializeField] private string _enemyLayer = "Enemy";

        private int _enemyMask;

        public int CountCharges
        {
            get => _countCharges;
            set
            {
                _countCharges = value;
                OnChangedCharges?.Invoke(_countCharges);
            }
        }

        private void Awake()
        {
            _enemyMask = LayerMask.GetMask(_enemyLayer);
            _inputService.attackEvent.AddListener(OnAttack);
            CountCharges = _countCharges;
        }

        private void OnAttack()
        {
            if (CountCharges > 0)
            {
                CountCharges--;
                Vector3 _position = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                Ray ray = _camera.ScreenPointToRay(_position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, _distanceAttack, _enemyMask))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    Enemy target = hitObject.GetComponent<Enemy>();
                    if (target != null)
                    {
                        target.ReactToHit();
                    }
                }
            }
        }
    }
}
