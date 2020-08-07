using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using PriorityQueueDemo.Models.Interfaces;

namespace PriorityQueueDemo.Models
{
    [DataContract]
    public partial class PriorityQueue : IEntity
    {
        public PriorityQueue()
        {
            EntryTime = null;
            PickTime = null;
            EndTime = null;
        }

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }

        [DataMember] public int OrderId { get; set; }
        [DataMember] public int? UserId { get; set; }
        [DataMember] public DateTime? EntryTime { get; set; }
        [DataMember] public DateTime? PickTime { get; set; }
        [DataMember] public DateTime? EndTime { get; set; }
        [DataMember] public virtual QueueType QueueType { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}