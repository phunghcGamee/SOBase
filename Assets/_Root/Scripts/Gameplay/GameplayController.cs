using System;
using Pancake.Apex;
using Pancake.Scriptable;
using Pancake.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Pancake.SceneFlow
{
    [HideMonoScript]
    public class GameplayController : GameComponent
    {
        [SerializeField] private Transform canvasUI;
        [Header("BUTTON")] [SerializeField] private Button buttonHome;

        [Header("OTHER")] [SerializeField] private AudioComponent buttonAudio;
        [SerializeField] private ScriptableEventString changeSceneEvent;

        private void Start() { buttonHome.onClick.AddListener(GoToMenu); }

        private void GoToMenu() { changeSceneEvent.Raise(Constant.MENU_SCENE); }
    }
}