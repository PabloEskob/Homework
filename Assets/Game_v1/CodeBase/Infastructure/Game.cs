using Game_v1.CodeBase.Services.Input;

namespace Game_v1.CodeBase.Infastructure
{
    public sealed class Game
    {
        public static readonly GameInput GameInput = new();
        public static readonly IInputService InputService = new InputService(GameInput);
    }
}