using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    public GameObject sinkPrefab;
    public GameObject toiletPrefab;
    public GameObject bedPrefab;
    public int numberOfSinks;
    public int numberOfToilets;
    public int numberOfBeds;
    public Transform[] sinkArray;
    public Transform[] toiletArray;
    public Transform[] bedArray;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numberOfSinks; i++)
        {
            Instantiate(sinkPrefab, sinkArray[i].position, sinkArray[i].rotation);
        }
        for (int i = 0; i < numberOfToilets; i++)
        {
            Instantiate(toiletPrefab, toiletArray[i].position, toiletArray[i].rotation);
        }
        for (int i = 0; i < numberOfBeds; i++)
        {
            Instantiate(bedPrefab, bedArray[i].position, bedArray[i].rotation);
        }
    }
}
