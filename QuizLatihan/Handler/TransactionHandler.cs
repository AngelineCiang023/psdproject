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

        public List<object> GetTransactionDetailsById(int id)
        {
            var transaction = _transactionRepo.GetTransactionByIdWithDetails(id);
            if (transaction == null)
                return new List<object>();

            return transaction.TransactionDetails
                .Select(td => new
                {
                    TransactionID = td.TransactionID,
                    JewelName = td.MsJewel.JewelName,
                    Quantity = td.Quantity
                })
                .ToList<object>();
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return _transactionRepo.GetTransactionById(id);
        }
    }
}
