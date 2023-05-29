using UnityEngine;

public class RobotActuator : MonoBehaviour
{
    [SerializeField]
    private GameObject Head;

    [SerializeField]
    private GameObject RightArmJoint;

    [SerializeField]
    private GameObject LeftArmJoint;

    [SerializeField]
    private GameObject RightLegJoint;

    [SerializeField]
    private GameObject LeftLegJoint;

    [SerializeField]
    private float LimbRotationSpeed = 3.0f;

    private float RightArmTargetAngle = 45.0f;
    private float LeftArmTargetAngle = 70.0f;
    private float RightLegTargetAngle = 0.0f;
    private float LeftLegTargetAngle = 0.0f;

    private void Start()
    {
        if (Head == null)
        {
            Debug.LogErrorFormat("Missing 'Head' GameObject!");
        }
        if (RightArmJoint == null)
        {
            Debug.LogErrorFormat("Missing 'RightArmJoint' GameObject!");
        }
        if (LeftArmJoint == null)
        {
            Debug.LogErrorFormat("Missing 'LeftArmJoint' GameObject!");
        }
        if (RightLegJoint == null)
        {
            Debug.LogErrorFormat("Missing 'RightLeg' GameObject!");
        }
        if (LeftLegJoint == null)
        {
            Debug.LogErrorFormat("Missing 'LeftLeg' GameObject!");
        }
    }

    private void Update()
    {
        RotateLimb(RightArmJoint, RightArmTargetAngle);
        RotateLimb(LeftArmJoint, LeftArmTargetAngle);
        RotateLimb(RightLegJoint, RightLegTargetAngle);
        RotateLimb(LeftLegJoint, LeftLegTargetAngle);
    }

    private void RotateLimb(GameObject limb, float limbTargetAngle)
    {
        Quaternion limbRot = limb.transform.localRotation;
        Vector3 limbRotEuler = limbRot.eulerAngles;
        if (!Mathf.Approximately(limbRotEuler.x, limbTargetAngle))
        {
            float deltaAngle = limbTargetAngle - limbRotEuler.x;

            Vector3 localRotationAxis = limb.transform.InverseTransformVector(Vector3.right);

            limb.transform.Rotate(localRotationAxis, deltaAngle * LimbRotationSpeed * Time.deltaTime);
        }
    }
}
