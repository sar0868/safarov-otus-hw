using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "RowData", menuName = "Data/Row/RowData")]
    public sealed class RowData : ScriptableObject
    {
        [SerializeField] private Color _color;

        public Color Color
        {
            get { return _color; }
        }
    }
}
