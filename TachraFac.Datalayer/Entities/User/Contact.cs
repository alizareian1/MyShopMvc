using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachraFac.Datalayer.Entities.User
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; } // متن پیام کاربر


        #region Relation
        public int ContactTypeId { get; set; } 
        public ContactType ContactType { get; set; } // ارتباط با User

        public int UserId { get; set; } // چون Identity از نوع string استفاده می‌کند
        public User User { get; set; }
        #endregion
    }
}
