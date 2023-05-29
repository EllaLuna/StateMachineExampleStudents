using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _rotationX = 0;

    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    // Use this for initialization
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Mouse Y") * sensitivityVer;
        _rotationX -= deltaX;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float deltaY = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + deltaY;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0.0f);
    }
}
