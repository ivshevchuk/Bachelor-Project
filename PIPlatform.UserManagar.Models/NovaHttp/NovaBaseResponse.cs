namespace PIPlatform.UserManagar.Models.NovaHttp
{
    public class NovaBaseResponse<T>
    {
        public string success { get; set; }
        public T[] data { get; set; }
    }
}
