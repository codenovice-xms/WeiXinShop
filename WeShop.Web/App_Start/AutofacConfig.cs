﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace WeShop
{
    public class AutofacConfig
    {
        public static void RegisterDenpendency()
        {
            // 1、创建一个容器配置对象
            var builder=new ContainerBuilder();
            // 2、注册当前MVC应用里的所有控制器（自动注册，只需要给它提供 要注册的程序集，在这里注册的使自己）
            // Assembly.GetExecutingAssembly() 就是获取当前运行中的程序的所有的类
            // PropertiesAutowired() 表示使用属性的方式进行 依赖注入
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var service = Assembly.Load("WeShop.Service");
            var repository = Assembly.Load("WeShop.Repository");

            var iService = Assembly.Load("WeShop.IService");
            var iRepository = Assembly.Load("WeShop.IRepository");

            // 4、注册接口的实现方（都来自与其他的程序集的类）
            builder.RegisterAssemblyTypes(service, iService).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repository, iRepository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            // 5、创建IoC容器对象
            var container = builder.Build();

            // 6、替换掉MVC内置的 控制器实例化对象 （转移 控制器实例化的 权限）
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}