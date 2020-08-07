using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PriorityQueueDemo.Models
{
    [DataContract]
    public class KContent<T>
    {
        [DataMember(EmitDefaultValue = false)] public T Result { get; set; }

        [DataMember(EmitDefaultValue = false)] public IEnumerable<T> Results { get; set; }
    }
}
