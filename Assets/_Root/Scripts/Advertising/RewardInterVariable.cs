using Pancake.Monetization;
using Pancake.Scriptable;

namespace Pancake.SceneFlow
{
    using UnityEngine;

    [Searchable]
    [CreateAssetMenu(fileName = "ad_reward_inter_unit_wrapper.asset", menuName = "Pancake/AD/Reward Inter Variable")]
    [EditorIcon("scriptable_bind")]
    public class RewardInterVariable : ScriptableObject
    {
        [SerializeField] private StringPairVariable remoteConfigUsingAdmob;
        public AdUnitVariable admobRewardInter;
        public AdUnitVariable applovinRewardInter;

        public AdUnitVariable Context()
        {
            bool.TryParse(remoteConfigUsingAdmob.Value.value, out bool usingAdmob);
            return usingAdmob ? admobRewardInter : applovinRewardInter;
        }
    }
}