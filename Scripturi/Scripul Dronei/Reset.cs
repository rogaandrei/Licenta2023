using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public float threshold = -1f;
    public Canvas canvas;
    public GameObject textDrona;
    public GameObject drona;

   

    private void Update()
    {
        if (transform.position.y < threshold)
        {
            drona.SetActive(false);
            textDrona.SetActive(true);
            Invoke("ResetSceneWithDelay", 3f);
        }
    }

    private void ResetSceneWithDelay()
    {
        textDrona.SetActive(false);
        //textDrona.text = ""; // Clear the message
        ResetScene();
    }

    private void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
