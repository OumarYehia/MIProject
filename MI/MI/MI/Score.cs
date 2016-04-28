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


        private class ScoreComparerOnAndNumberOfDiamondsAndNodes : IComparer<Score>
        {
            int IComparer<Score>.Compare(Score a, Score b)
            {
                if (a == null || b == null) throw new NullReferenceException();

                if (a.NumberOfDiamonds == b.NumberOfDiamonds)
                    return a.NumberOfNodes.CompareTo(b.NumberOfNodes);
                else
                    return a.NumberOfDiamonds.CompareTo(b.NumberOfDiamonds);
            }
        }
        
        public int CompareTo(Score otherScore)
        {
            if (otherScore == null) throw new NullReferenceException();

            if (this.NumberOfDiamonds == otherScore.NumberOfDiamonds)
                return this.TimeElapsed.CompareTo(otherScore.TimeElapsed);
            else
                return -1 * this.NumberOfDiamonds.CompareTo(otherScore.NumberOfDiamonds);
        }

        public static IComparer<Score> ComparerOnAndNumberOfDiamondsAndNodes()
        {
            return (IComparer<Score>)new ScoreComparerOnAndNumberOfDiamondsAndNodes();
        }
    }

}
