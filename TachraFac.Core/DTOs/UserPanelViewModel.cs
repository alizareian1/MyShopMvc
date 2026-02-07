using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachraFac.Core.DTOs
{
    public class InformationUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegiisterDate { get; set; }
        public int Wallet { get; set; }
        public int PhoneNumber { get; set; }
        public int CodePosti { get; set; }
        public string Address { get; set; }
    }
}
