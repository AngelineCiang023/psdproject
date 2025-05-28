using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Repository
{
	public class CategoryRepository
	{
        static LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        public List<MsCategory> GetCategory()
        {
            return db.MsCategories.ToList();
        }
    }
}