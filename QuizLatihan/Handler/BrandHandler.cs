using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Handler
{
	public class BrandHandler
	{
        private BrandRepository _brandRepository;

        public BrandHandler()
        { 
            _brandRepository = new BrandRepository();
        }

        public List<MsBrand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }

    }
}