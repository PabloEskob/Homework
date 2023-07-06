using Data;

namespace PersistentProgress
{
    public interface IPersistentProgressService
    {
        WorldProgress WorldProgress { get; set; }
    }
}