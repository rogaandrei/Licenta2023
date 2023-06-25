using UnityEngine;

public class Monede_Invart : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
