using UnityEngine;

public class RecenterChild : MonoBehaviour
{
    [Tooltip("How tightly to keep the child centered. 1 = instant snap.")]
    [Range(0f, 1f)] public float snapStrength = 1f;

    [Tooltip("If true, resets rotation as well.")]
    public bool resetRotation = true;

    private Vector3 _targetPos = Vector3.zero;
    private Quaternion _targetRot = Quaternion.identity;

    void LateUpdate()
    {
        if (snapStrength >= 1f)
        {
            transform.localPosition = _targetPos;
            if (resetRotation)
                transform.localRotation = _targetRot;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, snapStrength);
            if (resetRotation)
                transform.localRotation = Quaternion.Slerp(transform.localRotation, _targetRot, snapStrength);
        }
    }
}
