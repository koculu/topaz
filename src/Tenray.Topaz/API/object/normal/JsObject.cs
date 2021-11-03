﻿using Microsoft.Collections.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using Tenray.Topaz.Core;

namespace Tenray.Topaz.API
{
    public partial class JsObject : IJsObject, IDictionary
    {
        private const string NullString = "null";

        readonly DictionarySlim<string, object> dictionary = new();

        public object this[object key] {
            get
            {
                if (key == null)
                    key = NullString;
                if (dictionary.TryGetValue(key.ToString(), out var value))
                    return value;
                return Undefined.Value;
            }
            set
            {
                Add(key, ConvertJsonElementToJsObject(value));
            }
        }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public ICollection Keys
        {
            get
            {
                var list = new List<object>(dictionary.Count);
                var keys = GetObjectKeys();
                foreach (var key in keys)
                {
                    list.Add(key);
                }
                return list;
            }
        }

        public ICollection Values {
            get {
                var list = new List<object>(dictionary.Count);
                foreach (var entry in dictionary)
                {
                    list.Add(entry.Value);
                }
                return list;
            }
        }

        public int Count => dictionary.Count;

        public bool IsSynchronized => false;

        public object SyncRoot => null;

        public void Add(object key, object value)
        {
            if (key == null)
                key = NullString;
            ref var entry = ref dictionary.GetOrAddValueRef(key.ToString());
            entry = value;
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public bool Contains(object key)
        {
            if (key == null)
                key = NullString;
            return dictionary.ContainsKey(key.ToString());
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }

        public void Remove(object key)
        {
            if (key == null)
                key = NullString;
            dictionary.Remove(key.ToString());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        public bool TryGetValue(object key, out object value)
        {
            if (key == null)
                key = NullString;
            if (dictionary.TryGetValue(key.ToString(), out value))
                return true;
            value = Undefined.Value;
            return false;
        }

        public IEnumerable GetObjectKeys()
        {
            foreach (var key in dictionary)
            {
                yield return key.Key;
            }
        }

        void IJsObject.UnwrapObject(ScriptExecutor scriptExecutor)
        {
            var keys = GetObjectKeys();
            foreach (var key in keys)
            {
                var skey = (string)key;
                ref var entry = ref dictionary.GetOrAddValueRef(skey);
                entry = scriptExecutor.GetValue(entry);
            }
        }

        public void SetValue(object key, object value)
        {
            if (key == null)
                key = NullString;
            var skey = (string)key;
            ref var entry = ref dictionary.GetOrAddValueRef(skey);
            entry = value;
        }
    }
}
