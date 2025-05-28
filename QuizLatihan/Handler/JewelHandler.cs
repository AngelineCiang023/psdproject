using System;
using System.Collections.Generic;
using System.Linq;
using QuizLatihan.Model;

namespace QuizLatihan.Handler
{
    public class JewelHandler
    {
        public static bool CreateJewel(TblJewel jewel)
        {
            try
            {
                using (var db = new Model1Entities())
                {
                    db.TblJewels.Add(jewel);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<TblJewel> GetAllJewels()
        {
            using (var db = new Model1Entities())
            {
                return db.TblJewels.ToList();
            }
        }

        public static TblJewel GetJewelById(int id)
        {
            using (var db = new Model1Entities())
            {
                return db.TblJewels.Find(id);
            }
        }

        public static bool UpdateJewel(TblJewel updatedJewel)
        {
            try
            {
                using (var db = new Model1Entities())
                {
                    var existing = db.TblJewels.Find(updatedJewel.JewelID);
                    if (existing != null)
                    {
                        existing.JewelName = updatedJewel.JewelName;
                        existing.JewelPrice = updatedJewel.JewelPrice;
                        existing.JewelStock = updatedJewel.JewelStock;
                        existing.CategoryID = updatedJewel.CategoryID;
                        existing.BrandID = updatedJewel.BrandID;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteJewel(int id)
        {
            try
            {
                using (var db = new Model1Entities())
                {
                    var jewel = db.TblJewels.Find(id);
                    if (jewel != null)
                    {
                        db.TblJewels.Remove(jewel);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
