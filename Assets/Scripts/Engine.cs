using UnityEngine;

/// <summary>
/// Класс инкапсулирует в себе логику связанную
/// с изменением скорости корабля.
/// </summary>
public class Engine : MonoBehaviour
{
    [SerializeField]
    private float MaximumSpeed;
    [SerializeField]
    private float MinimumSpeed = 0f;
    [SerializeField]
    private float Acceleration;

    private AccelerationDirection mCurrentAccelerationDirection;

    private Rigidbody2D mRigidbody;

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

    void Awake()
    {
        this.mRigidbody = GetComponent<Rigidbody2D>();
        if (mRigidbody == null)
        {
            Debug.LogError("Can not find rigidbody component");
        }
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
        ResetAccelerationDirection();
    }

    private void ResetAccelerationDirection()
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

        mRigidbody.velocity = transform.up * CurrentSpeed;
    }

    internal enum AccelerationDirection
    {
        Forward = 1,
        Hold = 0,
        Backward = -1
    }
}
