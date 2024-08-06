using Microsoft.Extensions.Configuration;
using Spectre.Console.Cli;

namespace Cloudy.Client.CLI.Commands.Accounts;

public static class Configuration
{
    private const string COMMAND_NAME = "accounts";

    public static void AddAccountCommands(this IConfigurator configurator)
    {
        configurator.AddBranch(COMMAND_NAME, accounts =>
        {
            accounts.AddCommand<ListAccountCommand>("ls")
                    .WithAlias("list")
                    .WithDescription("Lists all accounts with their names.");

            accounts.AddCommand<AddAccountCommand>("a")
                    .WithAlias("add")
                    .WithDescription("Add account.");
        });
    }
}
