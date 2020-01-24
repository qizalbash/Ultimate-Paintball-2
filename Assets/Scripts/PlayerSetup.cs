using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable = null;
    [SerializeField] GameObject[] gameObjectsToDisable = null;

    GameObject sceneCamera;

    private void Start()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            sceneCamera = GameObject.Find("SceneCamera");
            sceneCamera.SetActive(false);
        }
        else
        {
            DisableComponents();
            Util.SetLayerRecursively(gameObject, LayerMask.NameToLayer("RemotePlayer"));
        }
    }

    private void OnDisable()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // This is only to get rid of errors when exiting the game while in the unity editor
            if (sceneCamera != null) { sceneCamera.SetActive(true); }
        }
    }

    // Disables components and objects that should not be on a remote player
    void DisableComponents()
    {
        foreach (Behaviour _behaviour in componentsToDisable)
        {
            _behaviour.enabled = false;
        }

        foreach (GameObject _gameObject in gameObjectsToDisable)
        {
            _gameObject.SetActive(false);
        }
    }
}
