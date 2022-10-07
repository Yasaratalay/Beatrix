using Beatrix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Beatrix.ViewComponents
{
    //Birden fazla modeli tek bir url de göstermek için hepsini tek bir component altında tutmaya yarıyor.
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>()
            {
                new UserComment
                {
                    ID = 1,
                    UserName = "Yaşar"
                },
                new UserComment
                {
                    ID=2,
                    UserName="Barış"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Mehmet"
                }
            };

            return View(commentValues);
        }
    }
}
