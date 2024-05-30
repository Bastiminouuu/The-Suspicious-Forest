using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchEventSystem : MonoBehaviour
{
    public GameObject originalFirstSelected;
    public GameObject secondSelected;

    private void Start()
    {
        if (EventSystem.current != null)
        {
            originalFirstSelected = EventSystem.current.firstSelectedGameObject;
        }

        OpenOptionsPanel();
    }

    public void RestoreOriginalFocus()
    {
        if (originalFirstSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(originalFirstSelected);
        }
    }

    public void OpenOptionsPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(secondSelected.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
