using QuizLatihan.Model;
using QuizLatihan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizLatihan.Handler
{
 
    public class JewelHandler
	{
        private JewelRepository _jewelRepository;
        private BrandRepository _brandRepository;
        private CategoryRepository _categoryRepository;

        public JewelHandler()
        {
            _jewelRepository = new JewelRepository();
            _brandRepository = new BrandRepository();
            _categoryRepository = new CategoryRepository();
        }

        public void AddJewel(MsJewel jewel)
        {
            _jewelRepository.Add(jewel);
        }

        public List<MsJewel> GetAllJewels()
        {
            try
            {
                
                return _jewelRepository.GetAllJewel();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all jewels.", ex);
            }
        }

        public MsJewel GetJewelByIdWithDetails(int jewelId)
        {
            try
            {
                return _jewelRepository.GetJewelByIdWithDetails(jewelId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving jewel by ID.", ex);
            }
        }


        public void UpdateJewel(MsJewel jewel)
        {
            try
            {
                _jewelRepository.UpdateJewel(jewel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating jewel.", ex);
            }
        }

        public void DeleteJewel(int jewelId)
        {
            try
            {
                _jewelRepository.DeleteJewel(jewelId);
            }
            catch(Exception ex)
            {
                throw new Exception("error deleting jewel.", ex);
            }
        }


    }


}