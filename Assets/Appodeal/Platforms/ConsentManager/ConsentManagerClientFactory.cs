using ConsentManager.Common;
using ConsentManager.Platforms.Android;

namespace ConsentManager.Platforms
{
    internal static class ConsentManagerClientFactory
    {
        internal static IConsentManager GetConsentManager()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidConsentManager ();
#else
            return new Dummy.Dummy();
#endif
        }

        internal static IVendorBuilder GetVendorBuilder(string name, string bundle, string policyUrl)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidVendorBuilder (name, bundle, policyUrl);
#else
            return new Dummy.Dummy();
#endif
        }

        internal static IConsentFormBuilder GetConsentFormBuilder()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidConsentFormBuilder();
#else
            return new Dummy.Dummy();
#endif
        }

        internal static IConsentManagerException GetConsentManagerException()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidConsentManagerException();
#else
            return new Dummy.Dummy();
#endif
        }
    }
}