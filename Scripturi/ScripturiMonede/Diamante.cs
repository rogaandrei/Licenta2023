using UnityEngine;

public class Diamante : MonoBehaviour
{
    public float rotationSpeed = 10f; // Viteza de rotație a obiectului pe axa Y

    private void Update()
    {
        // Obține unghiurile curente de rotație
        Vector3 currentRotation = transform.eulerAngles;

        // Setează doar rotația pe axa Y
        float newYRotation = currentRotation.y + (rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(currentRotation.x, newYRotation, currentRotation.z);
    }
}
