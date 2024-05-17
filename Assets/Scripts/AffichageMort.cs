using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageMort : MonoBehaviour
{

    [SerializeField] GameObject MortAffichage;
    public Health healthscript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        MortAffichage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthscript.currentHealth <= 0)
        {
            Debug.Log("Mort");
            Time.timeScale = 0f;
            MortAffichage.SetActive(true);
            //SceneManager.LoadScene("SCN_menu");
        }
    }
}
