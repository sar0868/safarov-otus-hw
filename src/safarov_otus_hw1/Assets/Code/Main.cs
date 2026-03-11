using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class Main : MonoBehaviour
    {
        public static int CountBrick { get; set; }

        private void Awake()
        {
            CountBrick = 0;
        }

        private void Update()
        {
            if (CountBrick == 0)
            {
                SceneManager.LoadScene(2);
            }
        }

    }
}
