using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Factory
{
	public class JewelFactory
	{
        public static MsJewel CreateJewel(string name, int categoryId, int brandId, int price, int releaseYear)
        {
            return new MsJewel
            {
                JewelName = name,
                CategoryID = categoryId,
                BrandID = brandId,
                JewelPrice = price,
                JewelReleaseYear = releaseYear
            };
        }
    }
}