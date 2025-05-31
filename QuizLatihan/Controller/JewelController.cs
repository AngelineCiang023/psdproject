using QuizLatihan.Factory;
using QuizLatihan.Handler;
using QuizLatihan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace QuizLatihan.Controller
{
	public class JewelController
	{
		private JewelHandler jewelHandler = new JewelHandler();
		private BrandHandler brandHandler = new BrandHandler();
		private CategoryHandler categoryHandler = new CategoryHandler();

		public string AddJewel(string name, string categoryId, string brandId, string price, string releaseYear)
		{
			if(name.Length < 3 || name.Length > 25)
			{
				return "Name must be between 3 and 25 characters";
            }

            if (!int.TryParse(categoryId, out int categoryIdParsed)) 
            {
                return "Please select a category";
            }

			if(!int.TryParse(brandId, out int brandIdParsed))
			{
				return "Please select a brand";
			}

            if (!int.TryParse(price, out int priceParsed) || priceParsed <= 25)
            {
                return "Price must be greater than 25 dollars";
            }

            if (!int.TryParse(releaseYear, out int releaseYearParsed) || releaseYearParsed >= DateTime.Now.Year)
            {
                return $"Release Year must be less than {DateTime.Now.Year}";
            }

            var jewelData = JewelFactory.CreateJewel(name, categoryIdParsed, brandIdParsed, priceParsed, releaseYearParsed);

            jewelHandler.AddJewel(jewelData);

            return null;
        }


        public MsJewel GetJewelById(int jewelId)
        {
            return jewelHandler.GetJewelByIdWithDetails(jewelId);
        }

        public string UpdateJewel(int id, string name, string categoryId, string brandId, string price, string releaseYear)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 25)
                return "Name must be between 3 and 25 characters";

            if (!int.TryParse(categoryId, out int categoryIdParsed))
                return "Please select a valid category";

            if (!int.TryParse(brandId, out int brandIdParsed))
                return "Please select a valid brand";

            if (!int.TryParse(price, out int priceParsed) || priceParsed <= 25)
                return "Price must be greater than 25";

            if (!int.TryParse(releaseYear, out int releaseYearParsed) || releaseYearParsed >= DateTime.Now.Year)
                return $"Release year must be less than {DateTime.Now.Year}";

            var updatedJewel = JewelFactory.CreateJewel(name, categoryIdParsed, brandIdParsed, priceParsed, releaseYearParsed);
            updatedJewel.JewelID = id;

            try
            {
                jewelHandler.UpdateJewel(updatedJewel);
                return null;
            }
            catch (Exception ex)
            {
                return "Update failed: " + ex.Message;
            }
        }
        public void DeleteJewel(int id)
        {
            jewelHandler.DeleteJewel(id);
        }

    }


}