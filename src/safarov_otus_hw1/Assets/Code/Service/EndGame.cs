using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public event Action OnIsWin;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            OnIsWin?.Invoke();
        }
    }
}
