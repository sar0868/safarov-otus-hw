using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        public float baseDamage = 2.33212f;
        public int multiplier = 4;
        public int Hp = 100;
        private bool isDeath;
        private float damage;

        private void Start()
        {
            isDeath = false;
            Debug.Log($"health: {Hp}");
            Damage();
            Damage();
        }

        private void OnValidate()
        {
            // First();
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
            if (isDeath)
            {
                Debug.Log("Character is dead");
                return;
            }

            damage = baseDamage * multiplier;
            Debug.Log($"damage was caused: {damage:##.####}");
            int damageInt = (int)Mathf.Round(damage);
            Hp -= damageInt < Hp? damageInt: Hp;
            Debug.Log($"health: {Hp}");

            if (Hp == 0)
            {
                isDeath = true;
                Debug.Log("Character is dead");
            }
        }
    }
}
