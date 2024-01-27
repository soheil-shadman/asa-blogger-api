 namespace AsaBloggerApi.Src.Repositories{
    public sealed class Repository{
    private static Repository? _instance;
    public static Repository GetRepository()
        {
            _instance ??= new Repository();
            return _instance;
        }


}
}
