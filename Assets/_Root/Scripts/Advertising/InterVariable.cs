using Pancake.Monetization;
using Pancake.Scriptable;

namespace Pancake.SceneFlow
{
    using UnityEngine;

    [Searchable]
    [CreateAssetMenu(fileName = "ad_inter_unit_wrapper.asset", menuName = "Pancake/AD/Inter Variable")]
    [EditorIcon("scriptable_bind")]
    public class InterVariable : ScriptableObject
    {
        [SerializeField] private StringPairVariable remoteConfigUsingAdmob;
        public AdUnitVariable admobInter;
        public AdUnitVariable applovinInter;

        public AdUnitVariable Context()
        {
            bool.TryParse(remoteConfigUsingAdmob.Value.value, out bool usingAdmob);
            return usingAdmob ? admobInter : applovinInter;
        }
    }
}