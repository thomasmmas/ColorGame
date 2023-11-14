using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrigger4 : MonoBehaviour
{
   public string uiSceneName = "HelperUI4";
   public GameObject uiCanvas; // Reference to your UI Canvas or UI elements

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainGuyRig")) // Make sure the object entering the trigger is the player
        {
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainGuyRig")) // Make sure the object exiting the trigger is the player
        {
            SceneManager.UnloadSceneAsync(uiSceneName);
            uiCanvas.SetActive(false);
        }
    }
}