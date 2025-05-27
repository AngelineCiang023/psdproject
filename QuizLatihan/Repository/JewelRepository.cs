using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuizLatihan.Repository
{
	
	public class JewelRepository
	{
		static LocalDatabaseEntities2 db = new LocalDatabaseEntities2();

		public List<MsJewel> GetAllJewel()
		{
			return db.MsJewels.ToList();
		}

        public MsJewel GetJewelByIdWithDetails(int id)
        {
            return db.MsJewels
                .Include(j => j.MsCategory)  // Use lambda expression for related entity
                .Include(j => j.MsBrand)     // Use lambda expression for related entity
                .FirstOrDefault(j => j.JewelID == id);
        }

    }
}