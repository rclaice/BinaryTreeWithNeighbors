using System;
using System.Collections.Generic;
using System.Linq;

namespace Btree
{
    public class BinaryTree
    {


        public void AddNeighborsToTree(Node startNode)
        {
            Queue<Node> nodesQueue = new Queue<Node>();
            Queue<Node> childrenForLevel = new Queue<Node>();

            nodesQueue.Enqueue(startNode);
            do 
            {
                var node = nodesQueue.Dequeue();

                Console.WriteLine($"DeQueued {node.Label}");
                EnqueueChildren(childrenForLevel, node);
                if (nodesQueue.Count == 0)
                    HandleChildren(childrenForLevel);
            }
            
            while (nodesQueue.Count > 0);
            void HandleChildren(Queue<Node> nodes)
            {
                while (nodes.Count > 0)
                {
                    var child = nodes.Dequeue();
                    Console.WriteLine($"Handling {child.Label}");
                    nodesQueue.Enqueue(child);
                    child.Neighbor = nodes.Count == 0 ? null : nodes.Peek();
                }
            }

        }


        private  void EnqueueChildren(Queue<Node> nodesQueue, Node node)
        {
            if (null != node.Left)
            {
                Console.WriteLine(node.Left.Label);
                nodesQueue.Enqueue(node.Left);
            }
            if (null != node.Right)
            {
                Console.WriteLine(node.Right.Label);
                nodesQueue.Enqueue(node.Right);
            }
        }

        public List<Node> GetNodesWithNeighbors(Node node)
        {
            var nodes = new List<Node>();

            if (null != node.Neighbor)
                nodes.Add(node);
            if (null != node.Left)
                nodes.AddRange(GetNodesWithNeighbors(node.Left));
            if (null != node.Right)
                nodes.AddRange(GetNodesWithNeighbors(node.Right));
            return nodes;
        }
    }

    
}
