using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;

namespace ECommerce.Test
{
    public class FakeApplication : WebApplicationFactory<Program>
    {
        public FakeApplication()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        }
    }
}
