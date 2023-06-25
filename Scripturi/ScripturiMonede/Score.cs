using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; 
    public Text notificationText; 
    private int score = 0; 
    public List<GameObject> coins; 
    public string sceneName; 
    private bool notificationActive = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (coins.Contains(other.gameObject))
        {
            coins.Remove(other.gameObject); 
            other.gameObject.SetActive(false); 
            score++; 
            scoreText.text = "Score: " + score.ToString(); 

            if (score == 10)
            {
                StartCoroutine(ShowNotificationAndLoadScene());
            }
        }
    }

    private IEnumerator ShowNotificationAndLoadScene()
    {
        notificationActive = true; 
        yield return new WaitForSeconds(3f); 
        notificationActive = false;
        SceneManager.LoadScene(sceneName); 
    }

    private void Update()
    {
        notificationText.gameObject.SetActive(notificationActive); 
    }
}
