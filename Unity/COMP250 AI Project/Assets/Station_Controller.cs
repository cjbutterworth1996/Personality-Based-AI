using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    public GameObject sinkPrefab;
    public GameObject toiletPrefab;
    public int numberOfSinks;
    public int numberOfToilets;
    public Transform[] sinkArray;
    public Transform[] toiletArray;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < numberOfSinks; i++)
        {
            Instantiate(sinkPrefab, sinkArray[i].position, sinkArray[i].rotation);
        }
        for (int i = 0; i < numberOfToilets; i++)
        {
            Instantiate(sinkPrefab, toiletArray[i].position, toiletArray[i].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
