using UnityEngine;
using System.Collections;

public class BeaconController : MonoBehaviour
{

    [SerializeField]
    private GameObject Beacon;

    public void putBeacon()
    {
        Instantiate(Beacon, this.transform.position, Quaternion.identity);
    }

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
