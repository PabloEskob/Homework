using Data;

namespace PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public WorldProgress WorldProgress { get; set; }
    }
}