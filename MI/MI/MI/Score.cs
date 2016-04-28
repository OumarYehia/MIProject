using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public class Score : IComparable<Score>
    {
        public String AlgorithmName;
        public Int64 NumberOfNodes;
        public Int32 NumberOfDiamonds;
        public Boolean AllDiamondsCollected;
        public TimeSpan TimeElapsed;

        public Score(String algorithmName, Int64 numberOfNodes, Int32 numberOfDiamonds, Boolean allDiamondsCollected, TimeSpan timeElapsed)
        {
            AlgorithmName = algorithmName;
            NumberOfNodes = numberOfNodes;
            NumberOfDiamonds = numberOfDiamonds;
            AllDiamondsCollected = allDiamondsCollected;
            TimeElapsed = timeElapsed;
        }

        public int CompareTo(Score otherScore)
        {
            if (otherScore == null) throw new NullReferenceException();

            if (this.NumberOfDiamonds == otherScore.NumberOfDiamonds)
                return -1 * this.TimeElapsed.CompareTo(otherScore.TimeElapsed);
            else
                return this.NumberOfDiamonds.CompareTo(otherScore.NumberOfDiamonds);
        }
    }
}
