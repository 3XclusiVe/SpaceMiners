using UnityEngine;
using UnityEditorInternal;

/// <summary>
/// Позволяет добывать минералы.
/// </summary>
public class MineralExtractor : MonoBehaviour
{

    [SerializeField]
    private int ResourceCapacity = 1;
    [SerializeField]
    private GameObject Bagage;

    private int mCurrentCapacity = 0;
    private State mCurrentState = State.NotLoaded;

    /// <summary>
    /// Возвращает истину если, минеральный 
    /// экстрактор запонен минералами.
    /// </summary>
    /// <value><c>true</c> if is filled; otherwise, <c>false</c>.</value>
    public bool isFilled
    {
        get
        {
            return mCurrentCapacity >= this.ResourceCapacity;
        }

    }

    void Update()
    {
        if (mCurrentState == State.Loaded)
        {
            Bagage.SetActive(true);
        }
        if (mCurrentState == State.NotLoaded)
        {
            Bagage.SetActive(false);
        }
    }


    private void Extract(Mineral mineral)
    {
        mCurrentCapacity += mineral.getResource();
        mCurrentState = State.Loaded;
    }

    private void Unload()
    {
        mCurrentCapacity = 0;
        mCurrentState = State.NotLoaded;
    }

    // Use this for initialization
    void Start()
    {
        mCurrentCapacity = 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (isMineral(other))
        {
            if (!isFilled)
            {
                Mineral mineral = other.gameObject.GetComponent<Mineral>();
                this.Extract(mineral);
            }
        }

        if (isBase(other))
        {
            Unload();
        }
        
    }


    private bool isMineral(Collider2D other)
    {
        if (other.tag == "Mineral")
        {
            return true;
        }
        return false;
    }

    private bool isBase(Collider2D other)
    {
        if (other.tag == "Base")
        {
            return true;
        }
        return false;
    }

    internal enum State
    {
        Loaded,
        NotLoaded
    }


}
