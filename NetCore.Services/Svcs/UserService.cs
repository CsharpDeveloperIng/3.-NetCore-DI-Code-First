using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser //Service Class : Interface를 상속받은 후에 명시적으로 Interface를 구현해주어야함.
    {

        #region Private Method
        private IEnumerable<User> GetUserInfos()
        {
            return new List<User>()
            { 
                new User()
                {
                    UserID = "jadejs",
                    UserName = "김정수",
                    UserEMail = "jadejskim@gmail.com",
                    Password = "123456"
                }
            };
        }
        private bool checkTheUserInfo(string userid, string password)
        {
            return GetUserInfos().Where(u => u.UserID.Equals(userid) && u.Password.Equals(password)).Any(); // Any : 리스트 데이터 유무 체크
        }

        #endregion

        bool IUser.MatchTheUserInfo(LoginInfo login) //Interface 에 묶여있는 메소드라 Public Protect Private 사용 불가 
        {
            return checkTheUserInfo(login.UserID, login.Password);
        }
    }
}
