using UnityEngine;

public class ShipMangmentSystem : MonoBehaviour
{
    [SerializeField]
    private Engine MineEngine;
    [SerializeField]
    private Helm MineHelm;
    [SerializeField]
    private MineralExtractor MineMineralExtractor;
    [SerializeField]
    private BeaconController MineBeaconController;


    [SerializeField]
    private Transform Base;

    [SerializeField]
    private Transform TargetTransform;


    private Vector3 mDirection;
    private Vector3 mRightDirection;
    private Vector3 mLeftDirection;

    private State mCurrentState;

    void Awake()
    {
        mDirection = transform.up;
        mRightDirection = transform.right;
        mLeftDirection = -transform.right;
    }

    // Use this for initialization
    void Start()
    {
        mCurrentState = State.Searching;

    }
	
    // Update is called once per frame
    void Update()
    {
        if (MineMineralExtractor.isFilled)
        {
            mCurrentState = State.FlyToBase;
        }
        else
        {
            if (mCurrentState == State.FlyToBase)
            {
                GenerateNewTargetPosition();
            }
            mCurrentState = State.Searching;
        }

        switch (mCurrentState)
        {
            case State.Searching:
                Searching();
                break;

            case State.FlyToBase:
                FlyTo(Base.position);
                MineBeaconController.putBeacon();
                break;
        }
    }

    private void FlyTo(Vector3 TargetPosition)
    {
        mDirection = transform.up;
        mRightDirection = transform.right;
        mLeftDirection = -transform.right;

        Vector3 DirectionToTArget = (TargetPosition - this.transform.position).normalized;

        float MoveDirectionToTarget = Vector3.Dot(mDirection,
         
                                          DirectionToTArget);


        float RotateDirectionToTarget = Vector3.Dot(mRightDirection, 
                                            DirectionToTArget);
                                           

        if (MoveDirectionToTarget > 0)
        {
            MineEngine.Accelerate();
        }
        else if (MoveDirectionToTarget < -0)
        {
            MineEngine.Brake();
        }

        if (RotateDirectionToTarget > 0)
        {
            MineHelm.TurnRight();
        }
        else if (RotateDirectionToTarget < -0)
        {
            MineHelm.TurnLeft();
        }
    }



    /// <summary>
    /// Генерация новой позиции для цели.
    /// </summary>
    private void GenerateNewTargetPosition()
    {
        float CameraSizeY = Camera.main.orthographicSize;
        float CameraSizeX = Camera.main.aspect * CameraSizeY;
        Vector2 Center = new Vector2(Camera.main.transform.position.x, 
                             Camera.main.transform.position.y);

        Vector2 NewTargetPosition = Center +
                                    new Vector2(Random.Range(-CameraSizeX, CameraSizeX), 
                                        Random.Range(-CameraSizeY, CameraSizeY));

        TargetTransform.position = new Vector3(NewTargetPosition.x, 
            NewTargetPosition.y, TargetTransform.position.z);
    }

    /// <summary>
    /// Возвращает истину, если объект близко к 
    /// цели и ложь, если иначе.
    /// </summary>
    /// <returns><c>true</c>, if near was ised, <c>false</c> otherwise.</returns>
    /// <param name="TargetPosition">Target position.</param>
    private bool isNear(Vector3 TargetPosition)
    {
        Vector3 VectorToTarget = TargetPosition - transform.position;

        float DistanceToTarget = Vector3.Magnitude(VectorToTarget);

        if (DistanceToTarget > 2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Searching()
    {
        Vector3 TargetPosition = TargetTransform.position;
        if (isNear(TargetPosition))
        {
            GenerateNewTargetPosition();
        }
        FlyTo(TargetPosition);
    }

    internal enum State
    {
        Searching,
        FlyToBase
    }
}
