using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button continueButton;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    private int currentIndex = 0;
    private string[] dialogue = new string[]
    {
        "Hello there!",
        "This is the second dialogue.",
        "And here's the third one.",
        // Add more dialogues here.
    };

    private void Start()
    {
        ShowCurrentDialogue();
    }

    private void ShowCurrentDialogue()
    {
        if (currentIndex < dialogue.Length)
        {
            dialogueText.text = dialogue[currentIndex];
        }
        else
        {
            // No more dialogue, hide the UI or do something else.
        }
    }

    public void OnContinueButtonClicked()
    {
        audioSource.PlayOneShot(buttonClickSound); // Play sound on button click
        currentIndex++;
        ShowCurrentDialogue();
    }
}