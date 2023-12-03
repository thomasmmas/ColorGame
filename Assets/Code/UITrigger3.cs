using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrigger3 : MonoBehaviour
{
   public string uiSceneName = "HelperUI3";
   public GameObject uiCanvas; // Reference to your UI Canvas or UI elements

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainGuyRig")) // Make sure the object entering the trigger is the player
        {
            Debug.Log("Entered trigger zone: " + gameObject.name);
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainGuyRig")) // Make sure the object exiting the trigger is the player
        {
            Debug.Log("Exited trigger zone: " + gameObject.name);
            SceneManager.UnloadSceneAsync(uiSceneName);
            uiCanvas.SetActive(false);
        }
    }
}
