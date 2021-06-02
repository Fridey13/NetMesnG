namespace NetMesnG.Api.ConfigModels
{
    public class SwaggerOpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public OpenApiContacts OpenApiContacts { get; set; }
        
    }

    public class OpenApiContacts
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}