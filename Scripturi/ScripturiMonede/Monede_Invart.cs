using UnityEngine;

public class Monede_Invart : MonoBehaviour
{
    public float rotationSpeed = 10f; // Viteza de rotație a obiectului pe axa Z

    private void Update()
    {
        // Realizează rotația continuă pe axa Z
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
