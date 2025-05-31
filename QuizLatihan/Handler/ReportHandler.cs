using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using QuizLatihan.Repository;
namespace QuizLatihan.Handler
{
    public class ReportHandler
    {
        private readonly ITransactionRepository _repo;

        public ReportHandler()
        {
        }

        public ReportHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public List<TransactionHeader> GetDoneTransactions()
        {
            return _repo.GetTransactionsByStatus("Done");
        }

        internal void Load(string v)
        {
            throw new NotImplementedException();
        }

        internal void SetDataSource(List<TransactionHeader> reportData)
        {
            throw new NotImplementedException();
        }
    }
}
