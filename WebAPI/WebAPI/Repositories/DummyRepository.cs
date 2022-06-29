using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class DummyRepository : IDummyRepository
    {
        public string GetName()
        {
            return "Furkan";
        }
    }
}
