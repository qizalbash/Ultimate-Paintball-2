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
        }
    }

    private void OnDisable()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            sceneCamera.SetActive(true);
        }
    }

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
