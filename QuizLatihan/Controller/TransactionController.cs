using QuizLatihan.Factory;
using QuizLatihan.Handler;
using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace QuizLatihan.Controller
{

    public class TransactionController
    {
        private readonly TransactionHandler _transactionHandler;

        public TransactionController()
        {
            _transactionHandler = new TransactionHandler();
        }

        public List<object> GetTransactionDetailsById(int id)
        {
            return _transactionHandler.GetTransactionDetailsById(id);
        }
    }
}