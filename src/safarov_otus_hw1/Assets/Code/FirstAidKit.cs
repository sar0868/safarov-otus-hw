using UnityEngine;

namespace Code
{
    public class FirstAidKit : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("FirstAidKit"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

