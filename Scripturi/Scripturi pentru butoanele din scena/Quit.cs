using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    private void Start()
    {
        // Înregistrează metoda QuitGame() ca răspuns la evenimentul OnClick() al dispozitivului de input
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        // Închide aplicația
        Application.Quit();
    }
}
