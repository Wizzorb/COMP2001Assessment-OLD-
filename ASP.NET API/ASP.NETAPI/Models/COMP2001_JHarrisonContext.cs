using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.SqlClient;

#nullable disable

namespace APIcomp2001.Models
{
    public partial class COMP2001_JHarrisonContext : DbContext
    {
        public COMP2001_JHarrisonContext()
        {
        }

        public COMP2001_JHarrisonContext(DbContextOptions<COMP2001_JHarrisonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_JHarrison;User Id=JHarrison; Password=CekY396*");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_ID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_Email");

                entity.Property(e => e.UserFname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("user_FName");

                entity.Property(e => e.UserLname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("user_LName");

                entity.Property(e => e.UserPword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_PWord");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public string userRegister (User user, string responseMessage)
        {
            COMP2001_JHarrisonContext registerContext = new COMP2001_JHarrisonContext();
            responseMessage = registerContext.Database.ExecuteSqlRaw("EXEC Register @user_FName, @user_LName, @user_Email, @user_PWord",
                new SqlParameter("@user_FName", user.UserFname.ToString()),
                new SqlParameter("@user_LName", user.UserLname.ToString()),
                new SqlParameter("@user_Email", user.UserEmail.ToString()),
                new SqlParameter("@user_PWord", user.UserPword.ToString())
                ).ToString();
            return responseMessage;
        }

        public void userUpdate (int id, User user)
        {
            COMP2001_JHarrisonContext updateContext = new COMP2001_JHarrisonContext();
            updateContext.Database.ExecuteSqlRaw("EXEC UpdateUser @user_FName, @user_LName, @user_Email, @user_PWord, @user_ID",
                new SqlParameter("@user_FName", user.UserFname.ToString()),
                new SqlParameter("@user_LName", user.UserLname.ToString()),
                new SqlParameter("@user_Email", user.UserEmail.ToString()),
                new SqlParameter("@user_PWord", user.UserPword.ToString()),
                new SqlParameter("@user_ID", id)
                );
        }

        public int userValidate (string userEmail, string userPassword)
        {
            COMP2001_JHarrisonContext validateContext = new COMP2001_JHarrisonContext();
            int valid = validateContext.Database.ExecuteSqlRaw("EXEC ValidateUser @user_Email, @user_PWord",
                new SqlParameter("@user_Email", userEmail),
                new SqlParameter("@user_PWord", userPassword)
                );
            return valid;
        }

        public void userDelete (int userID)
        {
            COMP2001_JHarrisonContext deleteContext = new COMP2001_JHarrisonContext();
            deleteContext.Database.ExecuteSqlRaw("EXEC DeleteUser @user_ID",
                new SqlParameter("@user_ID", userID));
        }
    }
}
