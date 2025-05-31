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
        private transactionRepository repo = new transactionRepository();

        public List<TransactionHeader> GetOrdersByUser(int userId)
        {
            return repo.GetTransactionsByUser(userId);
        }

        public void UpdateTransactionStatus(int transactionId, string status)
        {
            repo.UpdateTransactionStatus(transactionId, status);
        }
    }
}