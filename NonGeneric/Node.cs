using System;
using System.Collections.Generic;

namespace PrioritizedEvents
{
    internal readonly struct Node : IEquatable<Node>, IComparable<Node>
    {
        public readonly Action Action;
        public readonly int Priority;

        public Node(Action action, int priority = 0)
        {
            Action = action;
            Priority = priority;
        }

        public override bool Equals(object obj) => obj is Node node && Equals(node);

        public bool Equals(Node other) => EqualityComparer<Action>.Default.Equals(Action, other.Action);

        public override int GetHashCode() => EqualityComparer<Action>.Default.GetHashCode(Action);

        public static bool operator ==(Node left, Node right) => left.Equals(right);

        public static bool operator !=(Node left, Node right) => !(left == right);

        public int CompareTo(Node other) => other.Priority - Priority;
    }
}