public static class MapAll
{
    // Place to map all endpoint groups
    public static void MapAllEndpoints(this WebApplication app)
    {
        // auth
        app.MapAuthEndpoints();
    }
}
