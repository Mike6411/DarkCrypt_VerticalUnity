using System.Collections;
using System.Collections.Generic;
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

    }

}
