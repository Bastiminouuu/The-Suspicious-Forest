using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeDelayIntro : MonoBehaviour
{
    [SerializeField] float ChangeTime;
    [SerializeField] string GameScene;

    private void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
            BGmusic.instance.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(GameScene);
        }
    }
}
