using Code.Cargo;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            CargoAI cargoAI = other.GetComponent<CargoAI>();
            cargoAI.Stop();
        }
    }
}
