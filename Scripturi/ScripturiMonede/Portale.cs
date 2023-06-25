using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portale : MonoBehaviour
{
    public List<GameObject> deselectObjects; 
    public GameObject sceneObject; 
    public string sceneName; 
    public Text notificationText; 
    private bool notificationActive = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (deselectObjects.Contains(other.gameObject))
        {
            deselectObjects.Remove(other.gameObject); 
            other.gameObject.SetActive(false); 
        }

        if (other.gameObject == sceneObject)
        {
            StartCoroutine(ShowNotificationAndLoadScene());
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

