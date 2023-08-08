using System;
using UnityEngine;
using UnityEngine.UI;

namespace FUSE.AndroidPlugin
{
    public class AndroidPluginSceneMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private AndroidJavaClass _unityClass;
        private AndroidJavaObject _unityActivity;
        private AndroidJavaObject _plugin;

        private void Start()
        {
            InitPlugin("com.example.unityplugin.ToastPlugin");
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ShowToast("Kamu berhasil!");
        }

        private void InitPlugin(string pluginName)
        {
            _unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _unityActivity = _unityClass.GetStatic<AndroidJavaObject>("currentActivity");
            _plugin = new AndroidJavaObject(pluginName);
            if (_plugin == null)
            {
                Debug.Assert(true, "Plugin Instance Error");
            }
            _plugin.CallStatic("ReceiveUnityActivity", _unityActivity);
        }

        private void ShowToast(string message)
        {
            _plugin.Call("ShowToast", message);
        }
    }
}
