using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    // Business Katmanında Abstract klasörü içinde yer alan interface'ler Service olarak adlandırılıyor.
    // Business katmanında Concrete klasörü içinde yer alan sınıflar Manager olarak adlandırılıyor.
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public Category GeyById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}
