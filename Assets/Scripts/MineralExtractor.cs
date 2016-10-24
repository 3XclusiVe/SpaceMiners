using UnityEngine;

/// <summary>
/// Позволяет добывать минералы.
/// </summary>
public class MineralExtractor : MonoBehaviour
{

    [SerializeField]
    private int ResourceCapacity = 1;

    private int mCurrentCapacity = 0;

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


    private void Extract(Mineral mineral)
    {
        mCurrentCapacity += mineral.getResource();
    }

    private void Unload()
    {
        mCurrentCapacity = 0;
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
                if (mineral != null)
                {
                    this.Extract(mineral);
                }

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
}
