using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        public float baseDamage = 2.33212f;
        public int multiplier = 4;
        public float health = 100f;
        private float damage;

        private void Start()
        {
            Debug.Log($"health: {health:###.###}");
            Damage();
        }

        private void OnValidate()
        {
            First();
        }

        private void First()
        {
            int dataInt = 34;
            float dataFloat = 23.9789677864f;
            bool dataBool = true;

            Debug.Log($"int: {dataInt}");
            Debug.Log($"float: {dataFloat}");
            Debug.Log($"bool: {dataBool}");
        }

        private void Damage()
        {
            damage = baseDamage * multiplier;
            Debug.Log($"damage was caused: {damage:##.####}");
            health -= damage;
            Debug.Log($"health: {health:###.###}");
        }
    }
}
