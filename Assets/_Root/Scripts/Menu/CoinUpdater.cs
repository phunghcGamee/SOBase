using Pancake.Scriptable;
using TMPro;
using UnityEngine;

namespace Pancake.SceneFlow
{
    public class CoinUpdater : GameComponent
    {
        [SerializeField] private TextMeshProUGUI textCoin;
        [SerializeField] private ScriptableEventNoParam eventUpdateCoin;

        private void Start()
        {
            OnNoticeUpdateCoin();
            eventUpdateCoin.OnRaised += OnNoticeUpdateCoin;
        }

        private void OnNoticeUpdateCoin() { textCoin.text = Data.Load(Constant.USER_CURRENT_COIN, 0).ToString(); }
    }
}