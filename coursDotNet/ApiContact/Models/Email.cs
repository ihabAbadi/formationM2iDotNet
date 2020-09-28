using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContact.Models
{
    public class Email
    {
        private int id;

        private string mail;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
