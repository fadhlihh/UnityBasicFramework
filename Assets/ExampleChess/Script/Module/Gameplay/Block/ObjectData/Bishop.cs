using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    [CreateAssetMenu(fileName = "Bishop", menuName = "Block/Bishop", order = 4)]
    public class Bishop : BlockBase
    {
        public override void SetAttackZone(int rowPosition, int columnPosition, int columnCount, int rowCount)
        {
            AttackZone.Clear();

            /// Diagonal 1
            int rowIndex;
            int columnIndex;
            if (columnPosition > rowPosition)
            {
                rowIndex = rowPosition - rowPosition;
                columnIndex = columnPosition - rowPosition;
                rowIndex = (rowIndex < 0) ? 0 : rowIndex;
                columnIndex = (columnIndex < 0) ? columnIndex - 1 : columnIndex;
            }
            else
            {
                rowIndex = rowPosition - columnPosition;
                columnIndex = columnPosition - columnPosition;
                rowIndex = (rowIndex < 0) ? 0 : rowIndex;
                columnIndex = (columnIndex < 0) ? columnIndex - 1 : columnIndex;
            }
            while (rowIndex < rowCount && columnIndex < columnCount)
            {
                if (rowIndex != rowPosition || columnIndex != columnPosition)
                {
                    AttackZone.Add(new AttackZone(rowIndex, columnIndex));
                }
                rowIndex++;
                columnIndex++;
            }

            /// Diagonal 2
            rowIndex = rowPosition;
            columnIndex = columnPosition;
            while (rowIndex >= 0 && columnIndex < columnCount)
            {
                if (rowIndex != rowPosition || columnIndex != columnPosition)
                {
                    AttackZone.Add(new AttackZone(rowIndex, columnIndex));
                }
                rowIndex--;
                columnIndex++;
            }

            /// Diagonal 3
            rowIndex = rowPosition;
            columnIndex = columnPosition;
            while (rowIndex < rowCount && columnIndex >= 0)
            {
                if (rowIndex != rowPosition || columnIndex != columnPosition)
                {
                    AttackZone.Add(new AttackZone(rowIndex, columnIndex));
                }
                rowIndex++;
                columnIndex--;
            }
        }
    }
}
