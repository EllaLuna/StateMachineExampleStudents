using UnityEngine;

public class SlowRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
