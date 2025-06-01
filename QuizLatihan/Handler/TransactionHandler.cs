<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizLatihan.Model;
=======
using QuizLatihan.Model;
using System.Collections.Generic;
>>>>>>> origin/cita-HandlenReportv2
using QuizLatihan.Repository;

namespace QuizLatihan.Handler
{
    public class TransactionHandler
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> origin/cita-HandlenReportv2
