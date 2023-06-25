using UnityEngine;
using UnityEngine.InputSystem;

public class Options : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;// Referință la obiectul meniului de opțiuni

    private void Start()
    {
        // Înregistrează metoda OpenOptionsMenu() ca răspuns la evenimentul OnClick() al dispozitivului de input
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OpenOptionsMenu);
    }

    private void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true); // Activează meniul de opțiuni
        mainMenu.SetActive(false); 
    }

}
