using System;
using UnityEngine;

namespace Code
{
    public class CharcterSpawner : MonoBehaviour
    {
        public Character Character;
        public int CountCharacter;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < CountCharacter; i++)
            {
                Instantiate(Character);
            }
        }
    }

}
