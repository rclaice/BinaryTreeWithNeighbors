using Btree;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
    public class BTreeDepthFirstTraversalTests
    {
        [Test]
        public void IfNodesHaveIntegerValuesGetSumForTree()
        {
            // arrange
            // arrange
            var root = new Node{Label = "A", Value = 10}; 
            var b = new Node{Label = "B", Value = 20};
            var c = new Node{Label = "C", Value = 30};
            var d = new Node{Label = "D", Value = 5};
            var e = new Node{Label = "E", Value = 25};
            var f = new Node{Label = "F", Value = 1};
            var btree = new BinaryTree();
            root.Left = b;
                b.Left = d;
                b.Right = e;
            root.Right = c;
                c.Right = f;

            // act
            var sumOfNodeValues = btree.GetSumOfNodeValues(root);
            
            // assert
            sumOfNodeValues.ShouldBe(91);
        }
   }
}