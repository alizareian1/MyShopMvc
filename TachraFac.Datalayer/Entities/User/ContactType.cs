using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachraFac.Datalayer.Entities.User
{
    public class ContactType
    {
        [Key]
        public int ContactId { get; set; } // آیدی نوع تماس
        public string ContactName { get; set; } // نام نوع تماس (مثلاً: شکایت، پیشنهاد، پشتیبانی)

        #region Relation
        public ICollection<Contact> contacts { get; set; }
        #endregion
    }
}
