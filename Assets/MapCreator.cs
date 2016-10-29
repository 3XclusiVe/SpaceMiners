using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour
{

    [SerializeField]
    private int MineralCount;

    [SerializeField]
    private GameObject BasePrefab;

    [SerializeField]
    private GameObject MineralPrefab;

    void Awake()
    {
        Vector3 BasePosition = GenerateRandomPositionInsideMap();
        Instantiate(BasePrefab, BasePosition, Quaternion.identity);

        for (int SpawnedMineral = 0; SpawnedMineral < MineralCount; SpawnedMineral++)
        {
            Vector3 MineralPosition = GenerateRandomPositionInsideMap();
            Instantiate(MineralPrefab, MineralPosition, Quaternion.identity);
        }
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
