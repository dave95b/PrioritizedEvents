using System;
using System.Collections.Generic;

namespace PrioritizedEvents
{
    public interface IPrioritizedEvent
    {
        void AddListener(Action listener);
        void AddListener(Action listener, int priority);
        void RemoveListener(Action listener);
    }

    public class PrioritizedEvent : IPrioritizedEvent
    {
        private readonly List<Node> listeners = new List<Node>();

        public void Invoke()
        {
            foreach (Node node in listeners)
                node.Action();
        }

        public void AddListener(Action listener) => AddListener(listener, 0);

        public void AddListener(Action listener, int priority)
        {
            Node node = new Node(listener, priority);
            int index = listeners.BinarySearch(node);

            if (index < 0)
                index = ~index;

            listeners.Insert(index, node);
        }

        public void RemoveListener(Action listener)
        {
            Node node = new Node(listener);
            listeners.Remove(node);
        }

        public void Clear() => listeners.Clear();
    }
}