using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitDemo.Messages
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }

    }
}
