using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.Models
{
    public class BaseTypeAttribute : Attribute
    {
        public BaseTypeAttribute(Type baseType)
        {
            this.BaseType = baseType;
        }

        public Type BaseType { get; private set; }
    }
}