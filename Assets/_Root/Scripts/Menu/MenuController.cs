using Pancake.Apex;
using Pancake.Scriptable;
using Pancake.Sound;
using Pancake.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Pancake.SceneFlow
{
    public class MenuController : GameComponent
    {
        [SerializeField] private Transform canvasUI;
        [Header("BUTTON")] [SerializeField] private Button buttonSetting;
        [SerializeField] private Button buttonTapToPlay;
        [SerializeField] private Button buttonShop;

        [Header("POPUP")] [SerializeField] private PopupShowEvent popupShowEvent;
        [SerializeField, NamePickup("Pancake.UI.UIPopup")] private string popupShop;

        [SerializeField, NamePickup("Pancake.UI.UIPopup")] private string popupSetting;

        [Header("OTHER")] [SerializeField] private AudioComponent buttonAudio;
        [SerializeField] private ScriptableEventString changeSceneEvent;

        private void Start()
        {
            buttonSetting.onClick.AddListener(ShowPopupSetting);
            buttonTapToPlay.onClick.AddListener(GoToGameplay);
            buttonShop.onClick.AddListener(ShowPopupShop);
        }

        private void GoToGameplay() { changeSceneEvent.Raise(Constant.GAMEPLAY_SCENE); }

        private void ShowPopupShop() { popupShowEvent.Raise(popupShop, canvasUI); }


        private void ShowPopupSetting()
        {
            //buttonAudio.PlayAudio();
            popupShowEvent.Raise(popupSetting, canvasUI);
        }
    }
}