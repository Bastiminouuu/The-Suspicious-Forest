using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameReelGame : MonoBehaviour
{
    public Button ButtonStart;
    public Animator transition;

    void Start()                    //Switch menu 
    {
        Button btn = ButtonStart.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Lancer le jeu");
        SceneManager.LoadScene("SCN_Start");
        //StartCoroutine(LoadLevel());
    }

    //IEnumerator LoadLevel()
    //{
    //    transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(1);

    //    SceneManager.LoadScene("SCN_Start");
    //}
}
