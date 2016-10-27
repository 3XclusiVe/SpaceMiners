using UnityEngine;
using System.Collections;

public class BeaconController : MonoBehaviour
{

    [SerializeField]
    private GameObject Beacon;

    public void putBeacon(Vector3 TargetPosition)
    {
        GameObject BeaconBO = Instantiate(Beacon, this.transform.position, Quaternion.identity) as GameObject;
        Beacon beacon = BeaconBO.GetComponent<Beacon>();
        beacon.Initialize(TargetPosition);
    }

}
