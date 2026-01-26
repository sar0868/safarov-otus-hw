using UnityEngine;

namespace Code
{
    public class Character : MonoBehaviour
    {
        public Renderer Renderer;
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void setColor(Color color)
        {
            Renderer.material.color = color;
        }

        public void IsEnemy(bool isEnemy)
        {
            if (isEnemy)
            {
                setColor(Color.red);
            } else
            {
                setColor(Color.blue);
            }
        }
    }
}