using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.ViewModels
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "사용자 아이디를 입력하세요.")]
        //Required : 필수 입력 ErrorMessage : Error 시 띄우는 메시지
        [MinLength(6,ErrorMessage ="사용자 아이디는 6자 이상 입력하세요.")] //최소 글자 수 
        [Display(Name = "사용자 아이디")] //보여지는 부분 ;
        public string UserID { get; set; }
        [Required(ErrorMessage = " 비밀 번호를 입력하세요")]
        [MinLength(6, ErrorMessage = "비밀번호는 6자 이상 입력하세요.")] //최소 글자 수 
        [Display(Name = "사용자 비밀번호")]
        public string Password { get; set; }
    }
}
