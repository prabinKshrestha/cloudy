using Microsoft.Extensions.Options;
using Spectre.Console.Cli;

namespace Cloudy.Client.CLI.Commands.Accounts;

public class ListAccountCommand(IOptions<AppSettings.AppSettings> appSettings) : Command<ListAccountCommand.Settings>
{
    private readonly IOptions<AppSettings.AppSettings> _appSettings = appSettings;

    public class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        Console.WriteLine(_appSettings.Value.ApiBaseUrl);

        // Replace this with your actual logic to fetch accounts
        var accounts = GetAccounts();

        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
        }
        else
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Name: {account.Name}");
            }
        }

        return 0;
    }

    private List<Account> GetAccounts()
    {
        // Placeholder implementation
        return new List<Account>
        {
            new Account { Name = "Account1" },
            new Account { Name = "Account2" },
            new Account { Name = "Account3" },
        };
    }
}

public class Account
{
    public string Name { get; set; }
}