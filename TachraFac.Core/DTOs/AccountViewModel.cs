using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachraFac.Core.DTOs
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public required string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی‌باشد")]
        public required string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public required string Password { get; set; }

        [Display(Name = " تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        [Compare("Password",ErrorMessage ="کلمه های عبور مغایرت دارند")]
        public required string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public required string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public required string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RemmemerMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public required string UserName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public required string ActiveCode { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        public string? Password { get; set; }

        [Display(Name = " تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کارکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string? RePassword { get; set; }
    }
}
