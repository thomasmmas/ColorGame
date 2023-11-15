using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrigger4 : MonoBehaviour
{
    public string uiSceneName = "HelperUI4";
    public GameObject uiCanvas; // Reference to your UI Canvas or UI elements

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainGuyRig"))
        {
        Debug.Log("Entered trigger zone: " + gameObject.name);
        SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
        
            if (uiCanvas != null)
            {
                Debug.Log("Activating UI Canvas");
                uiCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainGuyRig"))
        {
            Debug.Log("Exited trigger zone: " + gameObject.name);
            SceneManager.UnloadSceneAsync(uiSceneName);
        
            if (uiCanvas != null)
            {
                Debug.Log("Deactivating UI Canvas");
                uiCanvas.SetActive(false);
            }
        }
    }
}