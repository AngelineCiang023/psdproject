using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizLatihan.Model;
using QuizLatihan.Repository;

namespace QuizLatihan.Handler
{
    public class TransactionHandler
    {
        private readonly ITransactionRepository _transactionRepo;

        public TransactionHandler(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public List<TransactionHeader> GetOrdersByUser(int userId)
        {
            return _transactionRepo.GetTransactionsByUser(userId);
        }

        public List<TransactionHeader> GetUnfinishedTransactions()
        {
            return _transactionRepo.GetTransactionsByStatusNot(new List<string> { "Done", "Rejected" });
        }

        public void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            _transactionRepo.UpdateTransactionStatus(transactionId, newStatus);
        }
    }
}
