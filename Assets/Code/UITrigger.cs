/*using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
      // Reference to the Dialogue1 script on the HelperUI canvas
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
    }
}*/