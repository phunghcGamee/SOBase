using Coffee.UIEffects;
using Pancake.Apex;
using Pancake.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pancake.SceneFlow
{
    public class PopupSetting : UIPopup
    {
        [SerializeField, Foldout("Setting", Style = "Group")] private TextMeshProUGUI textVersion;
        [SerializeField, Foldout("Setting", Style = "Group")] private Button buttonMusic;
        [SerializeField, Foldout("Setting", Style = "Group")] private Button buttonSound;
        [SerializeField, Foldout("Setting", Style = "Group")] private Button buttonVibrate;
        [SerializeField, Foldout("Setting", Style = "Group")] private Button buttonUpdate;
#if UNITY_IOS
        [SerializeField, Foldout("Setting", Style = "Group")] private Button buttonRestore;
        [SerializeField, Foldout("Setting", Style = "Group")] private Pancake.IAP.ScriptableEventIAPNoParam restorePurchaseEvent;
#endif

        private bool _initialized;


        private UIEffect _musicUIEffect;
        private UIEffect _soundUIEffect;
        private UIEffect _vibrateUIEffect;

        public override void Init()
        {
            if (!_initialized)
            {
                _initialized = true;
                buttonMusic.onClick.AddListener(OnButtonMusicPressed);
                buttonSound.onClick.AddListener(OnButtonSoundPressed);
                buttonVibrate.onClick.AddListener(OnButtonVibratePressed);
                buttonUpdate.onClick.AddListener(OnButtonUpdatePressed);
#if UNITY_IOS
                buttonRestore.onClick.AddListener(OnButtonRestorePressed);
#endif
                buttonMusic.TryGetComponent(out _musicUIEffect);
                buttonSound.TryGetComponent(out _soundUIEffect);
                buttonVibrate.TryGetComponent(out _vibrateUIEffect);
            }

            Refresh();
        }

        private void OnButtonMusicPressed()
        {
            var state = Data.Load<bool>(Constant.SETTING_MUSIC_STATE);
            state = !state;
            Data.Save(Constant.SETTING_MUSIC_STATE, state);
            RefreshMusicState(state);
        }

        private void OnButtonSoundPressed()
        {
            var state = Data.Load<bool>(Constant.SETTING_SOUND_STATE);
            state = !state;
            Data.Save(Constant.SETTING_SOUND_STATE, state);
            RefreshSoundState(state);
        }

        private void OnButtonVibratePressed()
        {
            var state = Data.Load<bool>(Constant.SETTING_VIBRATE_STATE);
            state = !state;
            Data.Save(Constant.SETTING_VIBRATE_STATE, state);
            RefreshVibrateState(state);
        }

        private void OnButtonUpdatePressed() { C.GotoStore(); }

#if UNITY_IOS
        private void OnButtonRestorePressed()
        {
            restorePurchaseEvent?.Raise();
        }
#endif

        public override void Refresh()
        {
            textVersion.text = $"Version {Application.version}";
            var musicState = Data.Load<bool>(Constant.SETTING_MUSIC_STATE);
            var soundState = Data.Load<bool>(Constant.SETTING_SOUND_STATE);
            var vibrateState = Data.Load<bool>(Constant.SETTING_VIBRATE_STATE);

            RefreshMusicState(musicState);
            RefreshSoundState(soundState);
            RefreshVibrateState(vibrateState);
        }

        private void RefreshVibrateState(bool vibrateState)
        {
            if (vibrateState)
            {
                buttonVibrate.interactable = true;
                _vibrateUIEffect.effectMode = EffectMode.None;
            }
            else
            {
                buttonVibrate.interactable = false;
                _vibrateUIEffect.effectMode = EffectMode.Grayscale;
            }
        }

        private void RefreshSoundState(bool soundState)
        {
            if (soundState)
            {
                buttonSound.interactable = true;
                _soundUIEffect.effectMode = EffectMode.None;
            }
            else
            {
                buttonSound.interactable = false;
                _soundUIEffect.effectMode = EffectMode.Grayscale;
            }
        }

        private void RefreshMusicState(bool musicState)
        {
            if (musicState)
            {
                buttonMusic.interactable = true;
                _musicUIEffect.effectMode = EffectMode.None;
            }
            else
            {
                buttonMusic.interactable = false;
                _musicUIEffect.effectMode = EffectMode.Grayscale;
            }
        }
    }
}