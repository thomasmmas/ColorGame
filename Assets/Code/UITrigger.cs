using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITrigger : MonoBehaviour
{
    public string uiSceneName;

    private bool uiLoaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
            uiLoaded = true;
        }
    }
}
