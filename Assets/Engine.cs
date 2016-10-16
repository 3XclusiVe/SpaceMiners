using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private float MaximumSpeed;
    [SerializeField]
    private float MinimumSpeed = 0f;
    [SerializeField]
    private float Acceleration;

    private AccelerationDirection mCurrentAccelerationDirection;

    public float CurrentSpeed
    {
        get;
        private set;
    }

    /// <summary>
    /// Функция торможения, уменьшает значение текущей скорости.
    /// </summary>
    public void Brake()
    {
        mCurrentAccelerationDirection = AccelerationDirection.Backward;
    }

    /// <summary>
    /// Функция ускорения, увеличивает значение текущей скорости.
    /// </summary>
    public void Accelerate()
    {
        mCurrentAccelerationDirection = AccelerationDirection.Forward;
    }

    // Use this for initialization
    void Start()
    {
        this.CurrentSpeed = 0f;
        this.mCurrentAccelerationDirection = AccelerationDirection.Forward;
    }
	
    // Update is called once per frame
    void Update()
    {
        UpdateCurrentSpeed();
        ResetAcceleration();
    }

    private void ResetAcceleration()
    {
        mCurrentAccelerationDirection = AccelerationDirection.Hold;
    }

    private void UpdateCurrentSpeed()
    {
        this.CurrentSpeed += (int)mCurrentAccelerationDirection * Acceleration * Time.deltaTime;

        if (CurrentSpeed > MaximumSpeed)
        {
            CurrentSpeed = MaximumSpeed;
        }

        if (CurrentSpeed < MinimumSpeed)
        {
            CurrentSpeed = MinimumSpeed;
        }
    }

    internal enum AccelerationDirection
    {
        Forward = 1,
        Hold = 0,
        Backward = -1
    }
}
