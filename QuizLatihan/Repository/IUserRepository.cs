using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Repository
{
    public interface IUserRepository
    {
        MsUser GetUserById(int userId);
        void UpdatePassword(MsUser user, string newPassword);
    }
}