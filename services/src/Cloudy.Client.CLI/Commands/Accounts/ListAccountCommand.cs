using Microsoft.Extensions.Options;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Text.Json;

namespace Cloudy.Client.CLI.Commands.Accounts;

public class ListAccountCommand(IOptions<AppSettings.AppSettings> appSettings)
    : AsyncCommand<ListAccountCommand.Settings>
{
    private readonly IOptions<AppSettings.AppSettings> _appSettings = appSettings;
    private readonly HttpClient _httpClient = new();

    public class Settings : CommandSettings
    {}

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        try
        {
            var apiUrl = $"{_appSettings.Value.ApiBaseUrl}/api/accounts";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to retrieve accounts.");
                return -1;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var accounts = JsonSerializer.Deserialize<List<AccountUserDto>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
            }
            else
            {
                var table = new Table();
                table.AddColumn("Id");
                table.AddColumn("Account Name");
                table.AddColumn("User Email");
                
                foreach (var account in accounts)
                {
                    table.AddRow(account.Id, account.AccountName, account.UserEmail);
                }

                AnsiConsole.Write(table);
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message} {ex.StackTrace}");
            return -1;
        }
    }

    public class AccountUserDto
    {
        public required string Id { get; set; }
        public required string AccountName { get; set; }
        public required string UserEmail { get; set; }
    }
}
