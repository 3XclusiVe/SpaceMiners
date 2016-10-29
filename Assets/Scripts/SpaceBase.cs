using UnityEngine;
using System.Collections;

public class SpaceBase : MonoBehaviour
{


    [SerializeField]
    private int ShipsCount;

    [SerializeField]
    private GameObject ShipPrefab;

    void Awake()
    {
        for (int SpawnedShip = 0; SpawnedShip < ShipsCount; SpawnedShip++)
        {
            GameObject ShipGO = Instantiate(ShipPrefab, this.transform.position, Quaternion.identity) as GameObject;
            ShipMangmentSystem Ship = ShipGO.GetComponent<ShipMangmentSystem>();

            GameObject target = CreateTarget();

            Ship.Initialize(this.transform, target.transform);
        }
    }

    private GameObject CreateTarget()
    {
        float scale = 0.1f;
        GameObject target = GameObject.CreatePrimitive(PrimitiveType.Cube);
        target.transform.localScale = new Vector3(scale, scale, scale);

        target.transform.position = this.GenerateRandomPositionInsideMap();

        return target;
    }

    /// <summary>
    /// Генерация новой позиции.
    /// </summary>
    private Vector2 GenerateRandomPositionInsideMap()
    {
        float CameraSizeY = Camera.main.orthographicSize;
        float CameraSizeX = Camera.main.aspect * CameraSizeY;
        Vector2 Center = new Vector2(Camera.main.transform.position.x, 
                             Camera.main.transform.position.y);

        Vector2 NewTargetPosition = Center +
                                    new Vector2(Random.Range(-CameraSizeX, CameraSizeX), 
                                        Random.Range(-CameraSizeY, CameraSizeY));

        return NewTargetPosition;
    }

}
