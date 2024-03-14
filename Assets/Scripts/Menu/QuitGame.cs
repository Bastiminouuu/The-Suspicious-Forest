using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button Quitter;

    void Start()  //quitter le jeu
    {
        Button btn = Quitter.GetComponent<Button>();
        btn.onClick.AddListener(LeftGame);
    }

    void LeftGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}