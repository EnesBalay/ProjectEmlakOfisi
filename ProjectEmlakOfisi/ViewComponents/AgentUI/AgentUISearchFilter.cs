using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmlakOfisiUI.ViewComponents.AgentUI
{
    public class AgentUISearchFilter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
