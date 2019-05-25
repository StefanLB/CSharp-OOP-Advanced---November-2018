using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i+=2)
            {
                yield return stones[i];
            }

            int lastStone = (stones.Length - 1) % 2 == 0 ? (stones.Length - 2) : (stones.Length - 1);

            for (int i = lastStone; i > 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
