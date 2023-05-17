using Game_v1.CodeBase.Services.OtherServices;

namespace Game_v1.CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        GameInput GameInput { get; }
    }
}