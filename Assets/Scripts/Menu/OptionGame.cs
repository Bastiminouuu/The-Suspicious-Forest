using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionGame : MonoBehaviour
{
    public Button Options;

    void Start()                    //Switch menu 
    {
        Button btn = Options.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Lancer l'option");
        SceneManager.LoadScene("SCN_Settings");
    }
}
