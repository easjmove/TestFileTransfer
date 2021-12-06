using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileReciever.Models
{
    public class TransferClass
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
}
