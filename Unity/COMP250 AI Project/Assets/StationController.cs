using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
	public GameObject bedPrefab;
	public GameObject fridgePrefab;
	public GameObject sinkPrefab;
	public GameObject toiletPrefab;
	public int numberOfBeds;
	public int numberOfFridges;
	public int numberOfSinks;
	public int numberOfToilets;
	public Transform[] bedArray;
	public Transform[] fridgeArray;
	public Transform[] sinkArray;
	public Transform[] toiletArray;

	// Start is called before the first frame update
	private void Start()
	{
        for (int i = 0; i < numberOfBeds; i++)
        {
            Instantiate(bedPrefab, bedArray[i].position, bedArray[i].rotation);
        }
        for (int i = 0; i < numberOfFridges; i++)
        {
            Instantiate(fridgePrefab, fridgeArray[i].position, fridgeArray[i].rotation);
        }
        for (int i = 0; i < numberOfSinks; i++)
		{
			Instantiate(sinkPrefab, sinkArray[i].position, sinkArray[i].rotation);
		}
		for (int i = 0; i < numberOfToilets; i++)
		{
			Instantiate(toiletPrefab, toiletArray[i].position, toiletArray[i].rotation);
		}
	}
}
