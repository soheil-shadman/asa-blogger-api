using AsaBloggerApi.Src.Repositories;

namespace AsaBloggerApi.Src.Logics{
    public sealed class BlogLogic{
    private readonly Repository _repository;

    public BlogLogic(){
        _repository = Repository.GetRepository();
    }
}
}
