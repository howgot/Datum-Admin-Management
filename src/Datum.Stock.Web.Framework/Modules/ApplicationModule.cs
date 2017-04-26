﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Datum.Stock.Application;

namespace Datum.Stock.Web.Framework.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register Repository Module
            builder.RegisterModule(new RepositoryModule());

            //Application Services
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>));

            base.Load(builder);
        }
    }
}