using Btree;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
    public class BTreeAddNeighborTests
    {
        [SetUp]
        public void Setup()
        {
        }

/**
Given a binary tree, write a function that adds right sibling pointers to each of the nodes.
For instance, given:

     A
    / \
   B   C
  / \   \ 
 D   E   F

The function should modify the tree to be:

     A
    / \
   B-->C
  / \   \ 
 D-->E-->F
 
 
 **/
 

        [Test]
        public void RootOnlyTreeShouldHaveNodNeighbors()
        {
            // arrange
            var root = new Node{Label = "root"};
            var btree = new BinaryTree();
            // act
            btree.AddNeighborsToTree(root);
            var nodesWithNeighbors = btree.GetNodesWithNeighbors(root);
            // assert
            nodesWithNeighbors.ShouldBeEmpty();

        }

        [Test]
        public void OneLevelTreeShouldHaveOneNeighbor()
        {
            // arrange
            var root = new Node{Label = "A"}; 
            var b = new Node{Label = "B"};
            var c = new Node{Label = "C"};
            var btree = new BinaryTree();
            root.Left = b;
            root.Right = c;
            // act
            btree.AddNeighborsToTree(root);
            var nodesWithNeighbors = btree.GetNodesWithNeighbors(root);
            // assert
            nodesWithNeighbors.ShouldNotBeEmpty();
            nodesWithNeighbors.Count.ShouldBe(1);
            nodesWithNeighbors.ShouldContain(n => n.Label == "B");
            b.Neighbor.Label.ShouldBe("C");
            c.Neighbor.ShouldBe(null);
        }

        [Test]
        public void TwoLevelTreeShouldHaveThreeNeighbors()
        {
            // arrange
            var root = new Node{Label = "A"};
            var b = new Node{Label = "B"};
            var c = new Node{Label = "C"};
            var d = new Node{Label = "D"};
            var e = new Node{Label = "E"};
            var f = new Node{Label = "F"};
            var btree = new BinaryTree();
            root.Left = b;
            root.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;
            // act
            btree.AddNeighborsToTree(root);
            var nodesWithNeighbors = btree.GetNodesWithNeighbors(root);
            // assert
            nodesWithNeighbors.ShouldNotBeEmpty();
            nodesWithNeighbors.Count.ShouldBe(3);
            nodesWithNeighbors.ShouldContain(n => n.Label == "B");
            nodesWithNeighbors.ShouldContain(n => n.Label == "D");
            nodesWithNeighbors.ShouldContain(n => n.Label == "E");
            b.Neighbor.Label.ShouldBe("C");
            c.Neighbor.ShouldBe(null);
            d.Neighbor.Label.ShouldBe("E");
            e.Neighbor.Label.ShouldBe("F");
        }        

        [Test]
        public void TwoLevelTreeShouldHaveFourNeighbors()
        {
            // arrange
            var root = new Node{Label = "A"};
            var b = new Node{Label = "B"};
            var c = new Node{Label = "C"};
            var d = new Node{Label = "D"};
            var e = new Node{Label = "E"};
            var f = new Node{Label = "F"};
            var g = new Node{Label = "G"};
            var btree = new BinaryTree();
            root.Left = b;
            root.Right = c;
            b.Left = d;
            b.Right = e;
            c.Left = f;
            c.Right = g;
            // act
            btree.AddNeighborsToTree(root);
            var nodesWithNeighbors = btree.GetNodesWithNeighbors(root);
            // assert
            nodesWithNeighbors.ShouldNotBeEmpty();
            nodesWithNeighbors.Count.ShouldBe(4);
            nodesWithNeighbors.ShouldContain(n => n.Label == "B");
            nodesWithNeighbors.ShouldContain(n => n.Label == "D");
            nodesWithNeighbors.ShouldContain(n => n.Label == "E");
            b.Neighbor.Label.ShouldBe("C");
            c.Neighbor.ShouldBe(null);
            d.Neighbor.Label.ShouldBe("E");
            e.Neighbor.Label.ShouldBe("F");
        }        

        [Test]
        public void UnbalancedTreeShouldHaveFiveNeighbors()
        {

            // arrange
            var a = new Node{Label = "A"};
            var b = new Node{Label = "B"};
            var c = new Node{Label = "C"};
            var d = new Node{Label = "D"};
            var e = new Node{Label = "E"};
            var f = new Node{Label = "F"};
            var g = new Node{Label = "G"};
            var h = new Node{Label = "H"};
            var i = new Node{Label = "I"};
            var btree = new BinaryTree();
            /* a
              b  c
             d e  f 
             g    h i
            */

            a.Left = b;
                b.Left = d;
                    d.Left = g;
                b.Right = e;

            a.Right = c;
                c.Right = f;
                    f.Left = h;
                    f.Right = i;
            // act
            btree.AddNeighborsToTree(a);
            var nodesWithNeighbors = btree.GetNodesWithNeighbors(a);
            // assert
            nodesWithNeighbors.ShouldNotBeEmpty();
            nodesWithNeighbors.Count.ShouldBe(5);
            nodesWithNeighbors.ShouldContain(n => n.Label == "B");
            nodesWithNeighbors.ShouldContain(n => n.Label == "D");
            nodesWithNeighbors.ShouldContain(n => n.Label == "E");
            nodesWithNeighbors.ShouldContain(n => n.Label == "G");
            nodesWithNeighbors.ShouldContain(n => n.Label == "H");

            b.Neighbor.Label.ShouldBe("C");
            c.Neighbor.ShouldBe(null);
            d.Neighbor.Label.ShouldBe("E");
            e.Neighbor.Label.ShouldBe("F");
            g.Neighbor.Label.ShouldBe("H");
            h.Neighbor.Label.ShouldBe("I");
        }        
    }
}