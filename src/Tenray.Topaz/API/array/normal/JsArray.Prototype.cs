﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tenray.Topaz.Core;

namespace Tenray.Topaz.API
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "This is a JS prototype.")]
    public partial class JsArray
    {   
        public object at(int index)
        {
            if (index < 0)
                index = Count + index;
            return this[index];
        }

        public IJsArray concat(params IEnumerable[] arrays) {
            var result = new JsArray();
            result.AddArrayValues(arraylist);
            foreach (var arr in arrays)
            {
                result.AddArrayValues(arr);
            }
            return result;
        }

        public void constructor() { }
        public void copyWithin() { }
        public void entries() { }
        public void every() { }
        public void fill() { }
        public void filter() { }
        public void find() { }
        public void findIndex() { }
        public void flat() { }
        public void flatMap() { }
        public void forEach() { }
        public void includes() { }
        public void indexOf() { }
        public void join() { }
        public void keys() { }
        public void lastIndexOf() { }
        public void length() { }
        public void map() { }

        public object pop() {
            var last = arraylist.Count - 1;
            if (last < 0)
                return Undefined.Value;
            var item = arraylist[last];
            arraylist.RemoveAt(last);
            return item;
        }

        public int push(object item, params object[] items) {
            AddArrayValue(item);
            AddArrayValues(items);
            return arraylist.Count;
        }

        public void reduce() { }
        public void reduceRight() { }
        public void reverse() { }
        public void shift() { }
        public void slice() { }
        public void some() { }
        public void sort() { }
        public void splice() { }
        public void toLocaleString() { }
        public void toString() { }
        public void unshift() { }
        public void values() { }
    }
}
