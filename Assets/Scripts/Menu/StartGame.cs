using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public Button Jouer;

    void Start()                    //Switch menu 
    {
        Button btn = Jouer.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Lancer le jeu");
        SceneManager.LoadScene("SCN_lvl1");
    }
}