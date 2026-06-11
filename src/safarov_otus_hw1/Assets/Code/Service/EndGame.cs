using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
