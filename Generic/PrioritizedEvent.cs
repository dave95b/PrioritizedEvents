using System;
using System.Collections.Generic;

namespace PrioritizedEvents
{
    public interface IPrioritizedEvent<T>
    {
        void AddListener(Action<T> listener);
        void AddListener(Action<T> listener, int priority);
        void RemoveListener(Action<T> listener);
    }

    public class PrioritizedEvent<T> : IPrioritizedEvent<T>
    {
        private readonly List<Node<T>> listeners = new List<Node<T>>();

        public void Invoke(T value)
        {
            foreach (Node<T> node in listeners)
                node.Action(value);
        }

        public void AddListener(Action<T> listener) => AddListener(listener, 0);

        public void AddListener(Action<T> listener, int priority)
        {
            Node<T> node = new Node<T>(listener, priority);
            int index = listeners.BinarySearch(node);

            if (index < 0)
                index = ~index;

            listeners.Insert(index, node);
        }

        public void RemoveListener(Action<T> listener)
        {
            Node<T> node = new Node<T>(listener);
            listeners.Remove(node);
        }

        public void Clear() => listeners.Clear();
    }
}