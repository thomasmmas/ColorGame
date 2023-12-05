using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject InfoScreen;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        InfoScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            InfoScreen.SetActive(true);
            //QuitButton.SetActive(true);
        }

        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            paused = false;
            Time.timeScale = 1;
            InfoScreen.SetActive(false);
            //QuitButton.SetActive(false);
        }
    }
}
