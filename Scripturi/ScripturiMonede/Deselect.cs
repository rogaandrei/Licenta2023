using UnityEngine;
using UnityEngine.InputSystem;

public class Deselect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deselect object
            Deselect1();
        }
    }

    private void Deselect1()
    {
        // Implementați aici logica pentru deselectarea obiectului
        Debug.Log("Object deselected!");
    }
}
