using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Repository
{
    public class UserProfileRepository : IUserRepository
    {
        private LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        public MsUser GetUserById(int userId)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserID == userId);
        }

        public void UpdatePassword(MsUser user, string newPassword)
        {
            user.UserPassword = newPassword;
            db.SaveChanges();
        }
    }
}