using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    [CreateAssetMenu(fileName = "Knight", menuName = "Block/Knight", order = 2)]
    public class Knight : BlockBase
    {
        public override void SetAttackZone(int rowPosition, int columnPosition, int columnCount, int rowCount)
        {
            AttackZone.Clear();
            int row;
            int column;

            row = rowPosition - 2;
            if (row >= 0)
            {
                column = columnPosition - 1;
                if (column >= 0)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
                column = columnPosition + 1;
                if (column < columnCount)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
            }

            row = rowPosition - 1;
            if (row >= 0)
            {
                column = columnPosition - 2;
                if (column >= 0)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
                column = columnPosition + 2;
                if (column < columnCount)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
            }

            row = rowPosition + 1;
            if (row < rowCount)
            {
                column = columnPosition - 2;
                if (column >= 0)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
                column = columnPosition + 2;
                if (column < columnCount)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
            }

            row = rowPosition + 2;
            if (row < rowCount)
            {
                column = columnPosition - 1;
                if (column >= 0)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
                column = columnPosition + 1;
                if (column < columnCount)
                {
                    AttackZone.Add(new AttackZone(row, column));
                }
            }
        }
    }
}
