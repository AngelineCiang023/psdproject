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

        public JewelHandler()
        {
            _jewelRepository = new JewelRepository();
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

        public object GetJewelByIdWithDetails(int jewelId)
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


    }


}