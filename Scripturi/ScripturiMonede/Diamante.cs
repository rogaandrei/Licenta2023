using UnityEngine;

public class Diamante : MonoBehaviour
{
    public float rotationSpeed = 10f; 

    private void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;

        float newYRotation = currentRotation.y + (rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(currentRotation.x, newYRotation, currentRotation.z);
    }
}
