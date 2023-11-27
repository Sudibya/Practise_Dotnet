


namespace GameStore.API.Endpoints
{
    public static class EndpointMappings
    {
        public static void MapAllEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGamesEndpoints();
        routes.MapUserMasterEndpoints();
    }
    }
}