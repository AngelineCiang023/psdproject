using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizLatihan.Model;

namespace QuizLatihan.Repository
{
    public class transactionRepository
    {
        LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        public List<TransactionHeader> GetTransactionsByUser(int userId)
        {
            return db.TransactionHeaders
                     .Where(th => th.UserID == userId)
                     .OrderByDescending(th => th.TransactionDate)
                     .ToList();
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var transaction = db.TransactionHeaders.Find(transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = newStatus;
                db.SaveChanges();
            }
        }
    }
}