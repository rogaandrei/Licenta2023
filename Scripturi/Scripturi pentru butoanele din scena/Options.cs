using UnityEngine;
using UnityEngine.InputSystem;

public class Options : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    private void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OpenOptionsMenu);
    }

    private void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true); // Activează meniul de opțiuni
        mainMenu.SetActive(false); 
    }

}
