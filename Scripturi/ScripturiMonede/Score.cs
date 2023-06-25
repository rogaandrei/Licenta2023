using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // Referință la componenta Text pentru a afișa scorul
    public Text notificationText; // Referință la componenta Text pentru a afișa notificarea
    private int score = 0; // Scorul curent
    public List<GameObject> coins; // Lista de obiecte monedă
    public string sceneName; // Numele scenei către care să te întorci
    private bool notificationActive = false; // Starea notificării

    private void OnTriggerEnter(Collider other)
    {
        if (coins.Contains(other.gameObject))
        {
            coins.Remove(other.gameObject); // Eliminăm moneda din lista
            other.gameObject.SetActive(false); // Dezactivăm moneda atinsă
            score++; // Incrementăm scorul cu 1
            scoreText.text = "Score: " + score.ToString(); // Actualizăm textul afișat cu noul scor

            if (score == 10)
            {
                StartCoroutine(ShowNotificationAndLoadScene());
            }
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
