using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    [CreateAssetMenu(fileName = "Dragon", menuName = "Block/Dragon", order = 1)]
    public class Dragon : BlockBase
    {
        public override void SetAttackZone(int rowPosition, int columnPosition, int columnCount, int rowCount)
        {
            AttackZone.Clear();
            int startPositionRow = ((rowPosition - 1) < 0) ? rowPosition : (rowPosition - 1);
            int startPositionColumn = ((columnPosition - 1) < 0) ? columnPosition : (columnPosition - 1);
            int endPositionRow = ((rowPosition + 1) >= rowCount) ? rowPosition : (rowPosition + 1);
            int endPositionColumn = ((columnPosition + 1) >= columnCount) ? columnPosition : (columnPosition + 1);
            for (int rowIndex = startPositionRow; rowIndex <= endPositionRow; rowIndex++)
            {
                for (int columnIndex = startPositionColumn; columnIndex <= endPositionColumn; columnIndex++)
                {
                    if (rowIndex != rowPosition || columnIndex != columnPosition)
                    {
                        AttackZone.Add(new AttackZone(rowIndex, columnIndex));
                    }
                }
            }
        }
    }
}
