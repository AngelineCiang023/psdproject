using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Repository
{
	public class BrandRepository
	{
        static LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

        public List<MsBrand> GetBrands()
        {
            return db.MsBrands.ToList();
        }
    }
}