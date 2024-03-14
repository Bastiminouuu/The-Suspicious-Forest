using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnMenu : MonoBehaviour
{
    public Button Return;

    void Start()                    //Switch menu 
    {
        Button btn = Return.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("SCN_menu");
    }
}