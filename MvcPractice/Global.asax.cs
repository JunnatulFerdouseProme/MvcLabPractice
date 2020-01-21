using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using MvcPractice.Models;
using MvcLabPractice.Model.Model;

namespace MvcPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentViewModel, Student>();
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<MemberViewModel, Member>();
                cfg.CreateMap<Member, MemberViewModel>();
                cfg.CreateMap<OrderViewModel, Order>();
                cfg.CreateMap<Order, OrderViewModel>();

            });
        }
    }
}
