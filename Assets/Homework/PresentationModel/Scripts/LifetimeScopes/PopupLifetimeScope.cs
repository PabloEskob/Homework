using Homework.PresentationModel.Scripts.PresentationModel;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Popup;
using VContainer;
using VContainer.Unity;

namespace Homework.PresentationModel.Scripts.LifetimeScopes
{
    public class PopupLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<CharacterPopup>();
            builder.RegisterComponentInHierarchy<UserInfo>();
            builder.RegisterComponentInHierarchy<PlayerLevel>();
            builder.RegisterComponentInHierarchy<CharacterInfo>();
            builder.Register<PlayerLevelPresentationModel>(Lifetime.Singleton).As<IPlayerLevelPresentationModel>();
            builder.Register<UserInfoPresentationModel>(Lifetime.Singleton).As<IUserInfoPresentationModel>();
            builder.Register<CharacterInfoPresentationModel>(Lifetime.Singleton).As<ICharacterInfoPresentationModel>();
        }
    }
}