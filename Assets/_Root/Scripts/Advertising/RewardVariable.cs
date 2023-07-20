using Pancake.Monetization;
using Pancake.Scriptable;

namespace Pancake.SceneFlow
{
    using UnityEngine;

    [Searchable]
    [CreateAssetMenu(fileName = "ad_reward_unit_wrapper.asset", menuName = "Pancake/AD/Reward Variable")]
    [EditorIcon("scriptable_bind")]
    public class RewardVariable : ScriptableObject
    {
        [SerializeField] private StringPairVariable remoteConfigUsingAdmob;
        [SerializeField] private AdUnitVariable admobReward;
        [SerializeField] private AdUnitVariable applovinReward;

        public AdUnitVariable Context()
        {
            bool.TryParse(remoteConfigUsingAdmob.Value.value, out bool usingAdmob);
            return usingAdmob ? admobReward : applovinReward;
        }
    }
}