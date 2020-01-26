using UnityEngine;

// This class contains a couple of functions that are used in other scripts
public class Util
{
    // Sets the layer of _obj and all of its children to _newLayer
    public static void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null)
            return;

        obj.layer = newLayer;

        foreach (Transform _child in obj.transform)
        {
            if (_child == null)
                continue;

            SetLayerRecursively(_child.gameObject, newLayer);
        }
    }

    // Converts RPM (Rounds Per Minute) to a cooldown in seconds.
    public static float RPMToCooldown(float RPM) => 60 / RPM;
}