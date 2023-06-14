using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    [CreateAssetMenu(fileName = "Rook", menuName = "Block/Rook", order = 3)]
    public class Rook : BlockBase
    {
        public override void SetAttackZone(int rowPosition, int columnPosition, int columnCount, int rowCount)
        {
            AttackZone.Clear();

            /// Vertical
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                if (rowIndex != rowPosition)
                {
                    AttackZone.Add(new AttackZone(rowIndex, columnPosition));
                }
            }

            /// Horizontal
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                if (columnIndex != columnPosition)
                {
                    AttackZone.Add(new AttackZone(rowPosition, columnIndex));
                }
            }
        }
    }
}
