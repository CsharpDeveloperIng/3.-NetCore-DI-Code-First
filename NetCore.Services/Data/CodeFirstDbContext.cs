using Microsoft.EntityFrameworkCore;
using NetCore.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Data
{
    //Fluent API
    //상속
    //CodeFirstDbContext : 자식 클래스
    //DbContext : 부모 클래스
    public class CodeFirstDbContext :DbContext 
        // DbContext 사용을 위해  Nuget에서 Microsoft.EntityFrameworkCore 설치
        // DB 종류에 따라 Microsoft.EntityFrameworkCore.SqlServer 설치
    {
        // base : 생성자 상속
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options) 
        {

        }
        // DB 테이블 리스트 지정
        public DbSet<User> Users { get; set; }
        // Method 상속 , 부모클래스에서 OnModelCreating 메서드가 virtual 키워드로 지정이 되어있어야 override 메서드로 사용가능
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 4가지 작업 
            // DB 테이블 이름 변경
            modelBuilder.Entity<User>().ToTable(name: "User"); // name 변경
            // 복합 키 설정
            modelBuilder.Entity<UserRolesByUser>().HasKey(c => new { c.UserID, c.RoleID }); //컬럼이기때문에 람다식사용을 통해 자리만들기.
            // 컬럼 기본값 지정
            modelBuilder.Entity<User>(e =>
            {
                e.Property(e => e.IsMembershipWithdrawn).HasDefaultValue(value: false);
            });
            //인덱스 지정
            modelBuilder.Entity<User>().HasIndex(c => new { c.UserEMail });
        }
    }
}
