using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour
{
    private Vector3 mTargePosition;

    public void Initialize(Vector3 Target)
    {
        this.mTargePosition = Target;
    }

    public Vector3 getTargetPosition()
    {
        return mTargePosition;
    }

}
