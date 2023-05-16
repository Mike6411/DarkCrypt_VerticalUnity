using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemscript : MonoBehaviour
{
    public Mesh[] allGems;
    public Color[] allColors;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = allGems[Random.Range(0, allGems.Length)];
        GetComponent<MeshRenderer>().material.color = allColors[Random.Range(0, allColors.Length)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
