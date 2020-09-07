using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace PoW.Core
{
  public static class ObjectProvider
  {
    public static IServiceProvider ServiceProvider { get; private set; }

     static void Initialize()
    {
      var serviceCollection = new ServiceCollection();
      ConfigureServices(serviceCollection);
      ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<ContentManager>();
    }
  }
}
