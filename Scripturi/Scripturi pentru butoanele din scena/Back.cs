using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    private void Start()
    {
        
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OpenMainMenu);
    }

    private void OpenMainMenu()
    {
        optionsMenu.SetActive(false); 
        mainMenu.SetActive(true);
    }

}
