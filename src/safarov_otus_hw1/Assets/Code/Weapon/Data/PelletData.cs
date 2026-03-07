using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = nameof(PelletData),
    menuName = "Data/Pellet/PelletData")]
    public sealed class PelletData : ScriptableObject
    {
        [SerializeField] private float _scatter;

        public float Scatter
        {
            get
            {
                return _scatter;
            }
        }
    }
}
