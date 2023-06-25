using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public string sceneName; 

    private void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadSceneOnClick);
    }

    private void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
