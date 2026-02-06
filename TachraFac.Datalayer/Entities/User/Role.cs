using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachraFac.Datalayer.Entities.User
{
    public class Role
    {
        public Role()
        {
            
        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(70,ErrorMessage ="{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public string RoleTitle { get; set; }

        #region Relation
        public virtual List<UserRole> userRoles { get; set; }
        #endregion
    }
}
