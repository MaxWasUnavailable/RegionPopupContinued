using HarmonyLib;

namespace RegionPopupContinued.Patches;

[HarmonyPatch(typeof(RegionBlender))]
internal static class RegionBlenderPatches
{
    [HarmonyPatch(nameof(RegionBlender.SwitchRegion))]
    [HarmonyPrefix]
    private static void SwitchRegionPrefix(Region newRegion)
    {
        var regionNotification = "Now entering ";

        switch (newRegion.portRegion)
        {
            case PortRegion.alankh:
                regionNotification += "Al' Ankh...";
                break;

            case PortRegion.emerald:
                regionNotification += "Emerald Archipelago...";
                break;

            case PortRegion.medi:
                regionNotification += "Aestrin...";
                break;

            case PortRegion.none:
                regionNotification += "The open sea...";
                break;

            default:
                // If for some reason the region is null, or if a region is added in the future.
                return;
        }

        NotificationUi.instance.ShowNotification(regionNotification);
    }
}