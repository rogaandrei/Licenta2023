using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Back_Nivel : MonoBehaviour
{
    public string sceneName; // Numele scenei către care să te duci

    public void OnButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(sceneName); // Încarcă scena cu numele specificat în variabila sceneName
        }
    }
}
