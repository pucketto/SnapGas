using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGas.Models
{
    public class CollectionAttribute : Attribute
    {
        public string CollectonName { get; set; }
        public CollectionAttribute(string collectionName)
        {
            this.CollectonName = collectionName;
        }
    }
}