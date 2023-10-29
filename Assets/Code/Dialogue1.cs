using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] Dlines;
    public float textSpeed;
    public AudioSource dialogueAudio;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            if(textComp.text == Dlines[index])
            {
                NextLine();
                if(dialogueAudio != null && dialogueAudio.clip != null)
                {
                    dialogueAudio.Play();
                }
            }
            else
            {
                StopAllCoroutines();
                textComp.text = Dlines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in Dlines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < Dlines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
