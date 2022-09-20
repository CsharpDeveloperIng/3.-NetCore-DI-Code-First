using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Data.DataModels
{
    // 데이터 어노테이션 Data Annotations
    public class User
    {
        [Key,StringLength(50),Column(TypeName ="varchar(50)")] // 사용자 ID : 프라이머리 키 지정 /컬럼의 길이 지정/컬럼 유형 지정
                                                               // 길이와 varchar(x) 를 맞춰주어햠
        public string UserID { get; set; }
        [Required,StringLength(100),Column(TypeName="nvarchar(100")] // Required : NotNull 지정
        public string UserName { get; set; }
        [Required, StringLength(320), Column(TypeName = "nvarchar(320")]
        public string UserEMail { get; set; }
        [Required, StringLength(130), Column(TypeName = "nvarchar(130")]
        public string Password { get; set; }
        //[Required]
        public bool? IsMembershipWithdrawn { get; set; }
        [Required]
        public DateTime JoinedUtcDate { get; set; }
        //Foreign Key 지정
        [ForeignKey("UserID")] //
        public virtual ICollection<UserRolesByUser> UserRolesByUsers { get; set; }
    }
}
