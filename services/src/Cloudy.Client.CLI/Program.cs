using Cloudy.Client.CLI.AppSettings;
using Cloudy.Client.CLI.Commands.Accounts;
using Cloudy.Client.CLI.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .Configure<AppSettings>(configuration.Bind); 

var registrar = new TypeRegistrar(serviceProvider);


var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddAccountCommands();
});

return app.Run(args);