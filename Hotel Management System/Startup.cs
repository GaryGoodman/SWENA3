﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel_Management_System.Startup))]
namespace Hotel_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
