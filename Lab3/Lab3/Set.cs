using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class Set<T> : IEnumerable<T>
    {
        private readonly Dictionary<T, bool> _items;

        public Set()
        {
            _items = new Dictionary<T, bool>();
        }

        public void Add(T item)
        {
            if (!_items.ContainsKey(item))
            {
                _items.Add(item, true);
            }
        }

        public void Remove(T item)
        {
            if (_items.ContainsKey(item))
            {
                _items.Remove(item);
            }
        }

        public bool Contains(T item)
        {
            return _items.ContainsKey(item);
        }

        public int Count()
        {
            return _items.Keys.Count;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void UnionWith(Set<T> input)
        {
            foreach (var item in input.Where(item => !_items.ContainsKey(item)))
            {
                _items.Add(item, true);
            }
        }

        public void IntersectWith(Set<T> input)
        {
            var newSet = new Set<T>();
            foreach (var item in _items.Keys.Where(input.Contains))
            {
                newSet.Add(item);
            }
            Clear();
            foreach (var item in newSet)
            {
                _items.Add(item, true);
            }
        }

        public void DifferenceWith(Set<T> input)
        {
            var newSet = new Set<T>();
            foreach (var item in _items.Keys.Where(item => !input.Contains(item)))
            {
                newSet.Add(item);
            }
            Clear();
            foreach (var item in newSet)
            {
                _items.Add(item, true);
            }
        }

        public bool IsSubsetOf(Set<T> input)
        {
            return _items.Keys.All(input.Contains);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}