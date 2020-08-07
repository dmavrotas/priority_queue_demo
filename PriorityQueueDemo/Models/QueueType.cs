using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using PriorityQueueDemo.Models.Interfaces;

namespace PriorityQueueDemo.Models
{
    [DataContract]
    public class QueueType : IEntity
    {
        public QueueType()
        {
            PriorityQueue = new HashSet<PriorityQueue>();
            Created = DateTime.Now;
        }

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public int? Duration { get; set; }
        [DataMember] public int? Delay { get; set; }
        [DataMember] public DateTime Created { get; set; }
        
        public virtual ICollection<PriorityQueue> PriorityQueue { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}