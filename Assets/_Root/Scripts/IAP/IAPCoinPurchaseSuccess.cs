using Pancake.IAP;
using UnityEngine;

namespace Pancake.SceneFlow
{
    [CreateAssetMenu(fileName = "iap_coin_purchase_success", menuName = "Pancake/IAP/Coin Purchase Success Listener")]
    [EditorIcon("scriptable_event_listener")]
    public class IAPCoinPurchaseSuccess : IAPPurchaseSuccess
    {
        [SerializeField] private int amount;

        public override void Raise()
        {
            int currentCoin = Data.Load(Constant.USER_CURRENT_COIN, 0);
            currentCoin += amount;
            Data.Save(Constant.USER_CURRENT_COIN, currentCoin);
        }
    }
}