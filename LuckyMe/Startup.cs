﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuckyMe.Startup))]
namespace LuckyMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureIoc(app);
            ConfigureAuth(app);
        }
    }
}
