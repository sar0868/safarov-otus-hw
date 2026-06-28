using UnityEngine;

namespace Code
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _detectionRadus = 10.0f;
        [SerializeField] private EnemyAnimation _animations;

        private PlayerBehaviour _player;

        private void Awake()
        {
            _animations = GetComponent<EnemyAnimation>();
            _player = FindFirstObjectByType<PlayerBehaviour>();
        }
        private void OnEnable()
        {
            _player.OnDeath += AnimationVictory;
        }

        private void AnimationVictory()
        {
            _animations.AnimationVictory();
        }

        void OnDisable()
        {
            _player.OnDeath -= AnimationVictory;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadus);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 5f);
        }

        public void AttackPlayer()
        {
            _player.GetDamage(_damage);
        }
    }
}
