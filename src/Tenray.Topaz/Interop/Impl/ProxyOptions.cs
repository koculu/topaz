﻿using System;

namespace Tenray.Topaz.Interop
{
    [Flags]
    public enum ProxyOptions
    {
        None,
        AllowConstructor,
        AllowMethod,
        AllowField,
        AllowProperty,
        AutomaticTypeConversion,
        ConvertStringArgumentsToEnum,
        Default = 
            AllowMethod |
            AllowField |
            AllowProperty |
            AllowConstructor |
            AutomaticTypeConversion |
            ConvertStringArgumentsToEnum
    }
}
