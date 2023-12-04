using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScreen : MonoBehaviour
{
    public string uiSceneName = "InfoScreen";
    public GameObject InfoScreen; // Reference to your UI Canvas or UI elements

    void update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && InfoScreen.activeSelf == false) // Make sure the object entering the trigger is the player
        {
            Debug.Log("In trigger zone: " + gameObject.name);
            SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
            InfoScreen.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InfoScreen.SetActive(false);
        }
    }
}