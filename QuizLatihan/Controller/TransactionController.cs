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
        private TransactionHandler transactionHandler = new TransactionHandler();

        public TransactionHeader GetTransactionById(int id)
        {
            return transactionHandler.GetTransactionById(id);
        }
    }
}