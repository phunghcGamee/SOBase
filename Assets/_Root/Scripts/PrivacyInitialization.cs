using Pancake.Apex;
using Pancake.Tracking;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif

namespace Pancake.SceneFlow
{
    using UnityEngine;
    
    [HideMonoScript]
    public class PrivacyInitialization : Initialize
    {
        public override void Init()
        {
#if UNITY_IOS
            SkAdNetworkBinding.SkAdNetworkRegisterAppForNetworkAttribution();
            SkAdNetworkBinding.SkAdNetworkUpdateConversionValue(HeartSettings.SkAdConversionValue);
#endif

            if (HeartSettings.EnablePrivacyFirstOpen && !Data.Load<bool>(Invariant.USER_AGREE_PRIVACY_KEY)) ShowPrivacy();
            else
            {
                RequestAuthorizationTracking();
            }
        }


        private static void RequestAuthorizationTracking()
        {
#if UNITY_IOS
            if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                ATTrackingStatusBinding.RequestAuthorizationTracking(CallbackAuthorizationTracking);
            }
            else
            {
                AppTracking.CreateAdjustObject();
            }
#else
            AppTracking.StartTrackingAdjust();
#endif
        }

        private static void CallbackAuthorizationTracking(int status)
        {
            AppTracking.StartTrackingAdjust();
            FirebaseTracking.TrackATTResult(status); // todo: need confirm work?
        }

        private static void PrivacyPolicyValidate(bool status)
        {
            if (status)
            {
                if (!Data.Load<bool>(Invariant.USER_AGREE_PRIVACY_KEY)) ShowPrivacy();
            }
        }

        private static void ShowPrivacy()
        {
            if (Application.isEditor) return;
            App.RemoveFocusCallback(PrivacyPolicyValidate);
            NativePopup.ShowNeutral(HeartSettings.PrivacyTitle,
                HeartSettings.PrivacyMessage,
                "Continue",
                "Privacy",
                "",
                () =>
                {
                    Time.timeScale = 1;
                    Data.Save(Invariant.USER_AGREE_PRIVACY_KEY, true);
                    App.RemoveFocusCallback(PrivacyPolicyValidate);

                    // Show ATT
                    RequestAuthorizationTracking();
                },
                () =>
                {
                    App.AddFocusCallback(PrivacyPolicyValidate);
                    Application.OpenURL(HeartSettings.PrivacyUrl);
                });
            Time.timeScale = 0;
        }
    }
}