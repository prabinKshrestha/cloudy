using System.Reflection;

namespace Cloudy.API.Infrastructures;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder CustomMapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name;
        return app.CustomMapGroup(groupName.ToLower());
    }

    public static RouteGroupBuilder CustomMapGroup(this WebApplication app, string groupName)
    {
        return app
            .MapGroup($"/api/{groupName.ToLower()}")
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
