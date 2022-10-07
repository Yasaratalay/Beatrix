using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Bir class'a ait tüm değerleri,nitelikleri kullan. Şart koyduk
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity); // buraya ne gönderirsek onun değerini alır. Blog,Category,About sınıfı gibi.
        void Delete(T entity); // buraya ne gönderirsek onun değerini alır. Blog,Category,About sınıfı gibi.
        void Update(T entity); // buraya ne gönderirsek onun değerini alır. Blog,Category,About sınıfı gibi.

        List<T> GetListAll(); // buraya ne gönderirsek onun değerini alır. Blog,Category,About sınıfı gibi.
        T GetById(int id); // Gönderilen ID bilgisine göre işlem yap. T olduğu için hangi class gönderirsek onunla ilgili iş yapar.
        List<T> GetListAll(Expression<Func<T,bool>> filter);
    }
}
