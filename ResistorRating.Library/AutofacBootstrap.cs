using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using ResistorRating.Library.Contracts;
using ResistorRating.Library.Services;

namespace ResistorRating.Library
{
    public class AutofacBootstrap
    {
        public static void Init(ContainerBuilder builder)
        {
            builder.RegisterType<LookupService>().As<ILookupService>();
            builder.RegisterType<OhmValueCalculatorService>().As<IOhmValueCalculator>();
        }
    }
}
