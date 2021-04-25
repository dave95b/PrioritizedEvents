using System;
using System.Collections.Generic;

namespace PrioritizedEvents
{
    internal readonly struct Node<T> : IEquatable<Node<T>>, IComparable<Node<T>>
    {
        public readonly Action<T> Action;
        public readonly int Priority;

        public Node(Action<T> action, int priority = 0)
        {
            Action = action;
            Priority = priority;
        }

        public override bool Equals(object obj) => obj is Node<T> node && Equals(node);

        public bool Equals(Node<T> other) => EqualityComparer<Action<T>>.Default.Equals(Action, other.Action);

        public override int GetHashCode() => EqualityComparer<Action<T>>.Default.GetHashCode(Action);

        public static bool operator ==(Node<T> left, Node<T> right) => left.Equals(right);

        public static bool operator !=(Node<T> left, Node<T> right) => !(left == right);

        public int CompareTo(Node<T> other) => other.Priority - Priority;
    }
}