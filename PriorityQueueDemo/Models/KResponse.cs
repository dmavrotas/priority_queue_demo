using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PriorityQueueDemo.Enums;

namespace PriorityQueueDemo.Models
{
    [DataContract]
    public class KResponse<T>
    {
        [DataMember] public EkResponseStatus Status { get; set; }

        [DataMember(EmitDefaultValue = false)] public KContent<T> Content { get; set; }

        [DataMember(EmitDefaultValue = false)] public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)] public IEnumerable<string> Errors { get; set; }
    }
}
