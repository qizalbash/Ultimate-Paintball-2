using UnityEngine;

// This class contains a couple of functions that are used in other scripts
public class Util
{
    // Sets the layer of _obj and all of its children to _newLayer
    public static void SetLayerRecursively(GameObject _obj, int _newLayer)
    {
        if (_obj == null)
        {
            return;
        }

        _obj.layer = _newLayer;

        foreach (Transform _child in _obj.transform)
        {
            if (_child == null)
            {
                continue;
            }

            SetLayerRecursively(_child.gameObject, _newLayer);
        }
    }

    // Converts RPM (Rounds Per Minute) to a cooldown in seconds.
    public static float RPMToCooldown(float _RPM)
    {
        return 60 / _RPM;
    }
}