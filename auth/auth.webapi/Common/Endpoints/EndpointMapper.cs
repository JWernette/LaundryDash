using System.Reflection;

namespace auth.webapi.Common.Endpoints;

public static class EndpointMapper
{
    // Grabs all methods with the Mapable attribute and invokes. This will create the mapping for minimal apis.
    public static void MapEndpoints(this WebApplication app, Type callingMethodType)
    {
        var callingContext = Assembly.GetExecutingAssembly();

        var mappingMethods = callingMethodType.GetMethods();

        var mapableMethods = mappingMethods.Where(x =>
            x.CustomAttributes.Any(x => x.AttributeType == typeof(MapableAttribute))
        );

        foreach (var method in mapableMethods)
        {
            var declaringType = method.DeclaringType;
            method.Invoke(declaringType, [app]);
        }
    }
}
