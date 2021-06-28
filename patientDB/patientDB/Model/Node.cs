using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    class Node
    {
        public int nodeId { get; }
        public int attributeId { set;  get; }
        public int patientId { set;  get; }
        public string value { get; set; }
        public Node(int nodeId, string value)
        {
            this.nodeId = nodeId;
            this.value = value;
        }
    }
}
