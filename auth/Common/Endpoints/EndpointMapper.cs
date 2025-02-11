using System.Reflection;
using Auth.Common;

namespace JobAssignments.API.Common;

public static class EndpointMapper
{
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
