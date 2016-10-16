using UnityEngine;

public class ShipMangmentSystem : MonoBehaviour
{

    public Engine MineEngine;
    public Rigidbody2D mRigidbody;


    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        int r = Random.Range(0, 3);
        if (r == 0)
        {
            //MineEngine.Brake();
        }
        if (r == 2)
        {
            MineEngine.Accelerate();
        }

        print(MineEngine.CurrentSpeed);

        mRigidbody.velocity = new Vector2(0, 1) * MineEngine.CurrentSpeed;

    }
}
