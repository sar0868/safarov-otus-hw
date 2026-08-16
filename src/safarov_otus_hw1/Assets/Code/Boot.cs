using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class Boot : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1);
        }
    }

}
