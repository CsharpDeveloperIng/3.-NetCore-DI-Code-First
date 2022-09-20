using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        //의존성 주입 - 생성자 주입
        // 닷넷 코어에서 기본적으로 제공하는 의존성 주입 방식인 생성자 주입
        // 생성자 주입 방식은 생성자의 파라미터를 통해 인터페이스를 지정하여 서비스클래스 인스턴스를 받아온다.

        //private IUser _user = new UserService();  
        private IUser _user;
        //Service Class : Interface에서 Service를 사용하기 위해 Service class 인스턴스를 받아온다.

        //(VS 2017) 의존성 주입을 위해 Startup.class의 ConfigureServices메소드에 추가 해준다.        
        //(VS 2022) 의존성 주입을 위해 Program.cs 에서 builder.Services.AddScoped를 통해 추가 해준다.
        public MembershipController(IUser user) 
        {
            _user = user; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] // Get 방식만 허용한다.
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] // Post 방식만 허용한다.
        [ValidateAntiForgeryToken] //위조 방지 토큰을 통해 View로 부터 받은 Post Data가 유효한지 검증합니다. 유효시 : 접근 가능 
        // Data => Services => Web
        // Data => Services
        // Data => Web
        public IActionResult Login(LoginInfo login)
        {
            string Message = string.Empty;
            if(ModelState.IsValid) // IsValid : 유효한 값인지 확인
            {
                //뷰모델이 데이터 프로젝트로 이동하고, 그곳에서 Data Model 과 View Model을 관리해준다.
                //서비스의 개념
                //1. 프로젝트를 분리
                //2. 모듈화를 통한 효율적 관리 

                // MVC 패턴시 사용 : if (login.UserID.Equals(userID) && login.Password.Equals(password))
                if(_user.MatchTheUserInfo(login))
                {
                    TempData["Message"] = "로그인이 성공적으로 완료되었습니다.";
                    return RedirectToAction("Index", "Membership"); // RedirectToAction : 뷰 이동 , 컨트롤러 이동
                }
                else
                {
                    Message = "로그인되지 않았습니다.";
                }
            }
            else
            {
                Message = "로그인 정보를 올바르게 입력하세요.";
            }
            ModelState.AddModelError(string.Empty, Message); //View 화면에 메시지를 띄워준다.
            return View();
        }
    }
}
