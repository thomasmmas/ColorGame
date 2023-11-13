using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrigger2 : MonoBehaviour
{
   public string uiSceneName = "HelperUI2";
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

    /*  // Reference to the Dialogue1 script on the HelperUI canvas
    public Dialogue1 dialogueBox; // Assuming Dialogue1 is a script attached to a dialogue box

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainGuyRig"))
        {
            // Assuming Dialogue1 has a method to start or show dialogue
            if (dialogueBox != null)
            {
                dialogueBox.StartDialogue(); // Adjust this based on your Dialogue1 implementation
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainGuyRig"))
        {
            // Assuming Dialogue1 has a method to end or hide dialogue
            if (dialogueBox != null)
            {
                dialogueBox.EndDialogue(); // Adjust this based on your Dialogue1 implementation
            }
        }
    }*/
