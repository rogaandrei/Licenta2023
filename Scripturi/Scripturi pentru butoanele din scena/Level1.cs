using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
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


