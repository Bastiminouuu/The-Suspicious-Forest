using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Dialogue : MonoBehaviour
{
    public Mouvement Moove;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;


    //[SerializeField] GameObject MusicCalm, MusicEpic;


    public GameObject UI;
    public PlayableDirector Timeline;


    void Start()
    {
        Moove.canMoove = false;
        Moove.canJump = false;
        textComponent.text = string.Empty;

        //MusicEpic.SetActive(false);
        //MusicCalm.SetActive(true);

        StartDialogue();
    }

    void Update()
    {
        if (Input.GetButtonDown("BoutonA") || Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
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
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index <  lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            UI.SetActive(false);
            //lancer timeline de fin (perso qui se déplace vers enfant)
            Timeline.Play();

            Moove.canMoove = false;
            Moove.canJump = false;
        }
    }
}
