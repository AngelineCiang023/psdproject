using QuizLatihan.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QuizLatihan.Repository
{
    public interface ITransactionRepository
    {
        List<TransactionHeader> GetTransactionsByStatusNot(List<string> excludedStatus);
        void UpdateTransactionStatus(int transactionId, string newStatus);
        List<TransactionHeader> GetTransactionsByStatus(string status);
        List<TransactionHeader> GetTransactionsByUser(int userId);
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly LocalDatabaseEntities2 _db = new LocalDatabaseEntities2();

        public List<TransactionHeader> GetTransactionsByStatusNot(List<string> excludedStatus)
        {
            return _db.TransactionHeaders
                      .Where(t => !excludedStatus.Contains(t.TransactionStatus))
                      .ToList();
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var transaction = _db.TransactionHeaders.Find(transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = newStatus;
                _db.SaveChanges();
            }
        }

        public List<TransactionHeader> GetTransactionsByStatus(string status)
        {
            return _db.TransactionHeaders
                      .Where(t => t.TransactionStatus == status)
                      .Include(t => t.TransactionDetails)
                      .ToList();
        }

        public List<TransactionHeader> GetTransactionsByUser(int userId)
        {
            return _db.TransactionHeaders
                .Where(t=>t.UserID == userId)
                .Include(t => t.TransactionDetails)
                .ToList();
        }
    }
}