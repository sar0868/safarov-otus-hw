using UnityEngine;

namespace Code
{
    public class Cycles : MonoBehaviour
    {
        public int Count;
        public string Msg;

        private void Start()
        {
            // ExampleFor(Count);
            // ExampleDoWhile(Count);
            // ExampleWhile(Count);
            // ExampleForeach(Msg);
        }

        private void ExampleFor(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Debug.Log($"[For]{Msg}: {i+1}");
            }
        }

        private void ExampleDoWhile(int count)
        {
            int i = 0;
            do
            {
                i++;
                Debug.Log($"[doWhile]{Msg}: {i}");
                
            }
            while(i < count);
        }

        private void ExampleWhile(int count)
        {
            int i = 0;
            while (i < count)
            {
                i++;
                Debug.Log($"[While]{Msg}: {i}");
            }
        }

        private void ExampleForeach(string msg)
        {
            foreach (char ch in msg)
            {
                Debug.Log(ch);                
            }
            Debug.Log($"[Foreach] {msg}");
        }

    }
}