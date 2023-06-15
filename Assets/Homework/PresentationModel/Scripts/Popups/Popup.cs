using UnityEngine;

namespace Lessons.Architecture.PM.Popup
{
    public class Popup : MonoBehaviour
    {
        private ICallback _callback;

        public void Show(object args = null, ICallback callback = null)
        {
            _callback = callback;
            OnShow(args);
        }

        public void Hide()
        {
            OnHide();
        }

        public void RequestClose()
        {
            _callback?.OnClose(this);
        }

        protected virtual void OnShow(object args)
        {
        }

        protected virtual void OnHide()
        {
        }

        public interface ICallback
        {
            void OnClose(Popup popup);
        }
    }
}