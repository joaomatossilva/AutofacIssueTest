using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Owin;

namespace AuthorizationServer
{
	public partial class Startup
	{
	    public void ConfigureAutofac(IAppBuilder app)
	    {
	        var builder = new ContainerBuilder();

	        builder.RegisterType<TestService>().AsSelf().InstancePerRequest();

	        var container = builder.Build();
	        app.UseAutofacMiddleware(container);
	        app.UseAutofacMvc();
	        app.UseAutofacWebApi(GlobalConfiguration.Configuration);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
	    }
	}
}