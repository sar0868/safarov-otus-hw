using UnityEngine;

namespace Code
{
    public class CharcterSpawner : MonoBehaviour
    {
        public Character Character;
        public int CountCharacter;

        private System.Random _random;

        private void Start()
        {
            Character.SetActive(false);
            _random = new System.Random();
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            for (int i = 1; i <= CountCharacter; i++)
            {
                Character character = Instantiate(Character, new Vector3(i, 0, i), Quaternion.identity);
                character.name = $"Character {i}";
                bool isEnemy = _random.Next(0, 2) == 0;
                character.IsEnemy(isEnemy);
                character.SetActive(true);
            }
        }
    }
}
