using Pancake.IAP;
using UnityEngine;

namespace Pancake.SceneFlow
{
    [CreateAssetMenu(fileName = "iap_allpinskin_purchase_success", menuName = "Pancake/IAP/All Pin Skin Purchase Success Listener")]
    [EditorIcon("scriptable_event_listener")]
    public class IAPAllPinSkinPurchaseSuccess : IAPPurchaseSuccess
    {
        public override void Raise()
        {
            // TODO unlock all skin here
        }
    }
}