using Microsoft.Extensions.Options;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Net.Http.Json;
using System.Text.Json;

namespace Cloudy.Client.CLI.Commands.Accounts;

public class AddAccountCommand(IOptions<AppSettings.AppSettings> appSettings)
    : AsyncCommand<AddAccountCommand.Settings>
{
    private readonly IOptions<AppSettings.AppSettings> _appSettings = appSettings;
    private readonly HttpClient _httpClient = new();

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<name>")]
        public required string AccountName { get; set; }

        [CommandArgument(1, "<email>")]
        public required string Email { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        try
        {
            var apiUrl = $"{_appSettings.Value.ApiBaseUrl}/api/accounts";
            var req = new AddAccountRequest(settings.AccountName, settings.Email);
            var response = await _httpClient.PostAsJsonAsync(apiUrl, req, _jsonOptions);

            Console.WriteLine($"Sending request to {apiUrl} with data: AccountName={settings.AccountName}, Email={settings.Email}");
            Console.WriteLine($"Sending request to {apiUrl} with data: AccountName={req.AccountName}, Email={req.Email}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to retrieve accounts.");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                return -1;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var accounts = JsonSerializer.Deserialize<AddAccountResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Account Name");
            table.AddColumn("User Id");
            table.AddColumn("User Email");
            table.AddRow(accounts!.AccountId.ToString(), settings.AccountName, accounts.UserId.ToString(), settings.Email);
            AnsiConsole.Write(table);

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message} {ex.StackTrace}");
            return -1;
        }
    }

    public record AddAccountRequest(string AccountName, string Email);
    public record AddAccountResponse(Guid AccountId, Guid UserId);
}
