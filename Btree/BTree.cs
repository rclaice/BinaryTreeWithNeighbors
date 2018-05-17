using System;
using System.Collections.Generic;

namespace Btree
{
    public class BinaryTree
    {


        public void AddNeighborsToTree(Node startNode)
        {
            Queue<Node> nodesQueue = new Queue<Node>();
            nodesQueue.Enqueue(startNode);

            while (nodesQueue.Count > 0)
            {
                var node = nodesQueue.Dequeue();
                var next = nodesQueue.Count > 0 ? nodesQueue.Peek() : null;
                Console.WriteLine($"DeQueued {node.Label}");
                SetNeighbor(node, next);
                SetNeighbor(node.Left, node.Right);
                SetNeighbor(node.Right, GetRightNeighbor(next));
                EnqueueChildren(nodesQueue, node);
            }
        }

        private static Node GetRightNeighbor(Node next) => 
            null == next ? null :  (next.Left != null ? next.Left : next.Right);

        private static void EnqueueChildren(Queue<Node> nodesQueue, Node node)
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

        private static void SetNeighbor(Node node, Node neighbor) {
            if (null == node || null == neighbor)
                return;
            node.Neighbor = neighbor;
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
