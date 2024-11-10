using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class BaseUI : MonoBehaviour, IUIAct, Manager.IInitializable
    {
        [SerializeField] private Graphic[] fadeGraphic;
        private UIFader[] uIFaders;

        IUIAct IUIAct.Show()
        {
            ExecuteOnShow();
            return this;
        }

        IUIAct IUIAct.Close()
        {
            ExecuteOnClose();
            return this;
        }

        IUIAct IUIAct.Hide()
        {
            ExecuteOnHide();
            return this;
        }

        protected abstract IUIAct ExecuteOnShow();
        protected abstract IUIAct ExecuteOnClose();
        protected abstract IUIAct ExecuteOnHide();
        public abstract void Initialize(Manager.DataManager.Data dataManager);
    }

    public interface IUIAct
    {
        IUIAct Show();
        IUIAct Hide();
        IUIAct Close();
    }

}