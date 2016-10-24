using UnityEngine;
using System.Collections;

/// <summary>
/// Скрипт содержит описание минерала.
/// </summary>
public class Mineral : MonoBehaviour
{

    [SerializeField]
    private int ResourceCapacity = 5;

    private int mCurrentCapacity;

    // Use this for initialization
    void Start()
    {
        if (this.ResourceCapacity <= 0)
        {
            this.ResourceCapacity = 0;
        }
        mCurrentCapacity = this.ResourceCapacity;
    }

    public int getResource()
    {
        int ExtractedResource = 1;
        mCurrentCapacity -= ExtractedResource;
        if (mCurrentCapacity <= 0)
        {
            Destroy(this.gameObject);
        }
        return ExtractedResource;
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
