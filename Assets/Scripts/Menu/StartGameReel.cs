using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameReelGame : MonoBehaviour
{
    public Button ButtonStart;
    public PlayableDirector Timeline;

    void Start()                    //Switch menu 
    {
        Timeline.time = 0;
        Button btn = ButtonStart.GetComponent<Button>();
        BGmusic.instance.GetComponent<AudioSource>().UnPause();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Lancer le jeu");
        Timeline.Play();
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SCN_Intro");
    }
}
