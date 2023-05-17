using Game_v1.CodeBase.Services.Input;
using Game_v1.CodeBase.Services.OtherServices;

namespace Game_v1.CodeBase.Infastructure
{
    public sealed class Bootstrap
    {
        public Bootstrap()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            AllServices.Container.RegisterSingle<GameInput>(new GameInput());
            AllServices.Container.RegisterSingle<IInputService>(
                new InputService(AllServices.Container.Single<GameInput>()));
        }
    }
}