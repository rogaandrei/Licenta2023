using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portale : MonoBehaviour
{
    public List<GameObject> deselectObjects; // Lista de obiecte de deselectat
    public GameObject sceneObject; // Obiectul care duce către scena nouă
    public string sceneName; // Numele scenei către care să te întorci
    public Text notificationText; // Referință la componenta Text pentru a afișa notificarea
    private bool notificationActive = false; // Starea notificării

    private void OnTriggerEnter(Collider other)
    {
        if (deselectObjects.Contains(other.gameObject))
        {
            deselectObjects.Remove(other.gameObject); // Eliminăm obiectul din lista de obiecte de deselectat
            other.gameObject.SetActive(false); // Dezactivăm obiectul atins
        }

        if (other.gameObject == sceneObject)
        {
            StartCoroutine(ShowNotificationAndLoadScene());
        }
    }

    private IEnumerator ShowNotificationAndLoadScene()
    {
        notificationActive = true; // Activează notificarea
        yield return new WaitForSeconds(3f); // Așteaptă timp de 3 secunde
        notificationActive = false; // Dezactivează notificarea
        SceneManager.LoadScene(sceneName); // Încarcă scena cu numele specificat în variabila sceneName
    }

    private void Update()
    {
        notificationText.gameObject.SetActive(notificationActive); // Activează sau dezactivează notificarea în funcție de starea curentă
    }
}

