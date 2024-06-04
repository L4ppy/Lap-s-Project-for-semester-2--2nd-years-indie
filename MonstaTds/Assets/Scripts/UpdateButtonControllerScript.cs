using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateButtonControllerScript : MonoBehaviour
{
    public GameObject UpdatePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableMenu()
    {
        if(UpdatePanel != null)

         UpdatePanel.SetActive(true);


    }


    public void DisableMenu()
    {
        if (UpdatePanel != null)
            UpdatePanel.SetActive(false);

    }

    
}
