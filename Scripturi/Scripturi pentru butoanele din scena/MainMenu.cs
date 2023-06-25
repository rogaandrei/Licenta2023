using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public string sceneName; // Numele scenei în care dorești să te arunci

    private void Start()
    {
        // Înregistrează metoda LoadSceneOnClick() ca răspuns la evenimentul OnClick() al dispozitivului de input
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadSceneOnClick);
    }

    private void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
