using System;
using NUnit.Framework;

public class BinarySearchTree<TKey> where TKey : IComparable<TKey>
{
    public BinarySearchTreeNode<TKey> Root { get; private set; }
    public int Count { get; private set; }

    public void Add(TKey key)
    {
        if (Root is null)
        {
            Root = new BinarySearchTreeNode<TKey>(key);
        }
        else
        {
            Add(Root, key);
        }

        Count++;
    }

    private void Add(BinarySearchTreeNode<TKey> node, TKey key)
    {
        int comparison = key.CompareTo(node.Key);

        if (comparison < 0)
        {
            if (node.Left is null)
            {
                node.Left = new BinarySearchTreeNode<TKey>(key);
            }
            else
            {
                Add(node.Left, key);
            }
        }
        else if (comparison > 0)
        {
            if (node.Right is null)
            {
                node.Right = new BinarySearchTreeNode<TKey>(key);
            }
            else
            {
                Add(node.Right, key);
            }
        }
        else
        {
            throw new ArgumentException("Duplicate key is not allowed.");
        }
    }
}

public class BinarySearchTreeNode<TKey>
{
    public TKey Key { get; }
    public BinarySearchTreeNode<TKey> Left { get; set; }
    public BinarySearchTreeNode<TKey> Right { get; set; }

    public BinarySearchTreeNode(TKey key)
    {
        Key = key;
    }
}

[TestFixture]
public class BinarySearchTreeTests
{
    [Test]
    public void TestBinarySearchTree_Add_ef0f5f201e()
    {
        // Arrange
        var tree = new BinarySearchTree<int>();

        // Act
        tree.Add(5);
        tree.Add(2);
        tree.Add(7);

        // Assert
        Assert.AreEqual(3, tree.Count);
        Assert.AreEqual(5, tree.Root.Key);
        Assert.AreEqual(2, tree.Root.Left.Key);
        Assert.AreEqual(7, tree.Root.Right.Key);
    }

    [Test]
    public void TestBinarySearchTree_Add_DuplicateKey_ThrowsException()
    {
        // Arrange
        var tree = new BinarySearchTree<int>();
        tree.Add(5);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => tree.Add(5));
    }
}