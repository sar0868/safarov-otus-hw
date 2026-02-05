using UnityEngine;

namespace Code
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private FirstAidKit _firstAidKit;
        [SerializeField] private int Count;
        private float size = 9.0f;

        private void Start()
        {
            SpawnFirstAidKits(Count);
            
        }

        private void SpawnFirstAidKits(int count)
        {
            for (int i = 0; i < count; i++)
            {
                float x = Random.Range(-size, size);
                float z = Random.Range(-size, size);
                FirstAidKit obj = Instantiate(_firstAidKit, new Vector3(x, 1.0f, z), Quaternion.identity );
                obj.name = $"FirstAidKit {i + 1}";
            }
        }
    }
}
