using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Texture2D[] maps;
    public GameObject wallPrefab;

    private Texture2D selectedMap;

    public List<Vector3> openPositions = new List<Vector3>();

    private Color wallColor = Color.black;

    public static MapManager instanceMapManager;

    private void Awake()
    {
        if(instanceMapManager == null) 
        {
            instanceMapManager = this;
        }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        GenerateNewMap();
    }

    public void GenerateNewMap()
    {
        //limpiar el mapa anterior
        openPositions.Clear();

        selectedMap = maps[Random.Range(0, maps.Length)];

        for (int x = 0; x < selectedMap.width; x++)
        {
            for (int y = 0; y < selectedMap.height; y++) 
            {
                GenerateTile(x, y);
            }
        }

    }

    private void GenerateTile (int x, int y)
    {
        Color pixelColor = selectedMap.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            openPositions.Add(new Vector3(x, 0, y));
            return;
        }

        if(pixelColor == wallColor)
        {
            Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
        }
    }

}
