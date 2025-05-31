using QuizLatihan.Model;
using System.Collections.Generic;
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
