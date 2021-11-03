﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tenray.Topaz.Core;

namespace Tenray.Topaz.API
{
    public partial class JsObject : DynamicObject
    {
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetValue(binder.Name, value);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return TryGetValue(binder.Name, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return GetObjectKeys().Cast<string>();
        }

        private static object ConvertJsonElementToJsObject(object value)
        {
            if (value == null)
                return null;
            if (value is JsonElement jsonElement)
                return jsonElement.ConvertToJsObject();
            return value;
        }
    }
}
