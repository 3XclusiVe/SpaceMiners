using UnityEngine;

/// <summary>
/// Класс инкапсулирует в себе логику связанную с изменением
/// направления движения корабля
/// </summary>
public class Helm : MonoBehaviour
{
    [SerializeField]
    private float RotationSpeed = 2.0f;

    public Vector2 CurrentMoveDirection
    {
        get;
        private set;
    }

    private RotationDirection mCurrentRotationDirection;
    private Vector3 mRotationAxis = Vector3.back;

    public void TurnRight()
    {
        mCurrentRotationDirection = RotationDirection.Right;
    }

    public void TurnLeft()
    {
        mCurrentRotationDirection = RotationDirection.Left;
    }

    // Use this for initialization
    void Start()
    {
        CurrentMoveDirection = this.transform.forward;
    }
	
    // Update is called once per frame
    void Update()
    {
        UpdateCurrentDirection();
        ResetRotationDirection();
    }

    void ResetRotationDirection()
    {
        mCurrentRotationDirection = RotationDirection.Hold;
    }

    void UpdateCurrentDirection()
    {
        Vector3 RotationDirectionVector = (int)mCurrentRotationDirection * mRotationAxis;

        transform.Rotate(RotationDirectionVector * RotationSpeed * Time.deltaTime);
    }

    internal enum RotationDirection
    {
        Right = 1,
        Hold = 0,
        Left = -1
    }
}
