using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob18 : IProblem
    {
        public int Solve()
        {
            int[][] triangle = new int[][]
            {
                   new int[]{3},
                  new int[]{7,4},
                 new int[]{2,4,6},
                new int[]{8,5,9,3}
            };

            //0, 1, 2, 3, [4], 5, 6, [7], [8], 9, 10, [11], [12], [13], 14


            //#1 0 0 0  0 {3,7,2,8}
            //#2 0 0 0  1 {3,7,2,5}

            //#3 0 0 1  1 {3,7,4,5}
            //#4 0 0 1  2 {3,7,4,9}

            //#5 0 1 1  1 {3,4,4,5}
            //#6 0 1 1  2 {3,4,4,9}

            //#7 0 1 2  2 {3,4,6,9}
            //#8 0 1 2  3 {3,4,6,3}


            //000
            //001
            //011
            //012

            int maxSum = 0;
            int maxLevel = triangle.Length;

            double loopCount = Math.Pow(2, maxLevel - 1) / 2;
            int[] route = new int[maxLevel - 1];
            for (int i = 0; i < loopCount; i++)
            {
                int[] row = triangle[i];

                // sum of route
                int routeLen = route.Length;
                int sum = 0;
                for (int j = 0; j < routeLen; j++)
                {
                    sum += row[route[j]];
                }

                sum += row[route[routeLen - 1]];
                sum += row[route[routeLen - 1] + 1];

                maxSum = sum > maxSum ? sum : maxSum;

                // update route
            }

            int[] arr = new int[] { 3, 7, 4, 2, 4, 6, 8, 5, 9, 3 };
            Graph g = new Graph();

            int sharedNodeCount = 0;
            int usedShareNodeCount = sharedNodeCount;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 3)
                {
                    sharedNodeCount++;
                    usedShareNodeCount = sharedNodeCount;
                }
            }

            g.AddNode(3);

            return 0;
        }
    }

    public class Graph
    {
        public IList<Node> Nodes
        {
            get;
            set;
        }
        
        public Node LastAddedNode
        {
            get { return this.Nodes == null ? null : this.Nodes.LastOrDefault(); }
        }

        public Node NotWellFormedNode
        {
            get { return this.Nodes == null ? null : this.Nodes.Where(n => n.DownLeftNode == null || n.DownRightNode == null).FirstOrDefault(); }
        }

        public void AddNode(int val, bool isShareNode = false)
        {
            if (this.Nodes == null || this.Nodes.Count == 0)
            {
                this.Nodes = new List<Node>();
                this.Nodes.Add(new Node(val));
                return;
            }

            Node newNode = new Node(val);
            Node notWellFormedNode = this.NotWellFormedNode;
            if (notWellFormedNode.DownLeftNode == null)
            {
                notWellFormedNode.DownLeftNode = newNode;
            }
            else if (notWellFormedNode.DownRightNode == null)
            {
                notWellFormedNode.DownRightNode = newNode;
            }

        }
    }

    public class Node
    {
        public Node(int content)
        {
            this.Content = content;
        }

        public Node UpLeftNode
        {
            get;
            set;
        }

        public Node UpRightNode
        {
            get;
            set;
        }

        public Node DownLeftNode
        {
            get;
            set;
        }

        public Node DownRightNode
        {
            get;
            set;
        }
        
        public int Content
        {
            get;
            set;
        }

        public bool IsRoot
        {
            get { return this.UpLeftNode == null && this.UpRightNode == null; }
        }

        public bool HasChildren
        {
            get { return this.DownLeftNode != null; }
        }
    }
}
