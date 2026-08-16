using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "RowUpgradeData", menuName = "Data/Row/Upgrade")]
    public sealed class RowUpgradeData : ScriptableObject
    {
        [Serializable]
        private class RowDataByLine
        {
            public int Line;
            public RowData RowData;
        }

        [SerializeField] private RowDataByLine[] _rowDataByLines;
        [SerializeField] private RowData _rowDataDefault;

        public bool TryGetRowDataLine(int line, out RowData rowData)
        {
            for (int i = 0; i < _rowDataByLines.Length; i++)
            {
                RowDataByLine rowDataByLine = _rowDataByLines[i];
                if (rowDataByLine.Line == line)
                {
                    rowData = rowDataByLine.RowData;
                    return true;
                }
            }
            rowData = _rowDataDefault;
            return false;
        }
    }
}
