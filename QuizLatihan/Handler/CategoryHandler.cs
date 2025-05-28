using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Handler
{
	public class CategoryHandler
	{
        private CategoryRepository _categoryRepository;

        public CategoryHandler()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<MsCategory> GetCategory()
        {
            return _categoryRepository.GetCategory();
        }
    }
}