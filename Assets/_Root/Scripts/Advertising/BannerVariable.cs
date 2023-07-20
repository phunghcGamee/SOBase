using Pancake.Monetization;
using Pancake.Scriptable;

namespace Pancake.SceneFlow
{
    using UnityEngine;

    [Searchable]
    [CreateAssetMenu(fileName = "ad_banner_unit_wrapper.asset", menuName = "Pancake/AD/Banner Variable")]
    [EditorIcon("scriptable_bind")]
    public class BannerVariable : ScriptableObject
    {
        [SerializeField] private StringPairVariable remoteConfigUsingAdmob;
        public AdUnitVariable admobBanner;
        public AdUnitVariable applovinBanner;

        public AdUnitVariable Context()
        {
            bool.TryParse(remoteConfigUsingAdmob.Value.value, out bool usingAdmob);
            return usingAdmob ? admobBanner : applovinBanner;
        }
    }
}