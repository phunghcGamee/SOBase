using Pancake.Monetization;
using Pancake.Scriptable;

namespace Pancake.SceneFlow
{
    using UnityEngine;

    [Searchable]
    [CreateAssetMenu(fileName = "ad_appopen_unit_wrapper.asset", menuName = "Pancake/AD/App Open Variable")]
    [EditorIcon("scriptable_bind")]
    public class AppOpenVariable : ScriptableObject
    {
        [SerializeField] private StringPairVariable remoteConfigUsingAdmob;
        public AdUnitVariable admobAppOpen;
        public AdUnitVariable applovinAppOpen;

        public AdUnitVariable Context()
        {
            bool.TryParse(remoteConfigUsingAdmob.Value.value, out bool usingAdmob);
            return usingAdmob ? admobAppOpen : applovinAppOpen;
        }
    }
}