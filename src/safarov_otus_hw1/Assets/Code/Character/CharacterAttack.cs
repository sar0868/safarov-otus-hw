using Code.Service;
using UnityEngine;


namespace Code.Character
{
    public sealed class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;
        [SerializeField] private Camera _camera;
        [SerializeField] private int _countBullets = 20;
        [SerializeField] private float _distanceAttack = 10.0f;
        [SerializeField] private string _enemyLayer = "Enemy";
        private int _enemyMask;

        public int CountBullets { get => _countBullets; set => _countBullets = value; }

        private void Start()
        {
            _inputService.attackEvent.AddListener(OnAttack);
            _enemyMask = LayerMask.GetMask(_enemyLayer);
        }

        private void OnAttack()
        {
            CountBullets--;
            Vector3 _position = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(_position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _distanceAttack, _enemyMask))
            {
                GameObject hitObject = hit.transform.gameObject;
                Enemy.Enemy target = hitObject.GetComponent<Enemy.Enemy>();
                if (target != null)
                {
                    target.ReactToHit();
                }
            }
        }
    }
}
