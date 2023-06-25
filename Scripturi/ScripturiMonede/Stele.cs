using UnityEngine;

public class Stele : MonoBehaviour
{
    public float rotationSpeed = 10f; // Viteza de rotație a obiectului pe axa X

    private void Update()
    {
        // Realizează rotația continuă pe axa X
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
