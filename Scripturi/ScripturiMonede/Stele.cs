using UnityEngine;

public class Stele : MonoBehaviour
{
    public float rotationSpeed = 10f; 
    private void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
