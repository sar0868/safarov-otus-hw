using UnityEngine;

namespace Code
{
    public sealed class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.startSpawn.OnEnterTag += Spawn;
        }

        private void OnDisable()
        {
            _player.startSpawn.OnEnterTag -= Spawn;
        }

        public void Spawn(Transform pos, int countEnemy)
        {
            for (int i = 0; i < countEnemy; i++)
            {
                Add(pos);
            }
        }

        private void Add(Transform pos)
        {
            Enemy enemy = Instantiate(_enemyPrefab, pos.position, Quaternion.identity);

        }
    }
}

