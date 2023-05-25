using Game_v1.CodeBase.Services.ServiceLocator;
using UnityEngine.SceneManagement;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class SceneController : ISceneController
    {
        public void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public interface ISceneController : IService
    {
        public void RestartCurrentScene();
    }
}