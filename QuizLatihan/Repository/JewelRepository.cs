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

        public void Add(MsJewel jewel)
        {
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

		public List<MsJewel> GetAllJewel()
		{
			return db.MsJewels.ToList();
		}

        public MsJewel GetJewelByIdWithDetails(int id)
        {
            return db.MsJewels
                .Include(j => j.MsCategory) 
                .Include(j => j.MsBrand)    
                .FirstOrDefault(j => j.JewelID == id);
        }

        public void UpdateJewel(MsJewel jewel)
        {
            var existingJewel = db.MsJewels.FirstOrDefault(j => j.JewelID == jewel.JewelID);
            if (existingJewel != null)
            {
                existingJewel.JewelName = jewel.JewelName;
                existingJewel.CategoryID = jewel.CategoryID;
                existingJewel.BrandID = jewel.BrandID;
                existingJewel.JewelPrice = jewel.JewelPrice;
                existingJewel.JewelReleaseYear = jewel.JewelReleaseYear;

                db.SaveChanges();
            }
            else
            {
                throw new Exception("Jewel not found");
            }
        }


    }
}