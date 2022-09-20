using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Data.DataModels
{
    public class UserRolesByUser
    {
        /// <summary>
        /// 사용자 소유 권한 
        /// </summary>
        [Key, StringLength(50), Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Key, StringLength(50), Column(TypeName = "varchar(50)")]
        public string RoleID { get; set; }
        [Required] // Required : 필수 값
        public DateTime OwnedUtcDate { get; set; }
        //Foregn Key
        public virtual User User { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
