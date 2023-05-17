namespace Game_v1.CodeBase.Services.Input
{
    public sealed class InputService : IInputService
    {
        public GameInput GameInput { get; }

        public InputService(GameInput gameInput)
        {
            GameInput = gameInput;
            GameInput.Enable();
        }
    }
}