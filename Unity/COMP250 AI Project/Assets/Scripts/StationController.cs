using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
	public GameObject bedPrefab;
	public GameObject computerPrefab;
	public GameObject fridgePrefab;
	public GameObject sinkPrefab;
	public GameObject toiletPrefab;
	public GameObject tvPrefab;
	public int numberOfBeds;
	public int numberOfComputers;
	public int numberOfFridges;
	public int numberOfSinks;
	public int numberOfToilets;
	public int numberOfTvs;
	public Transform[] bedArray;
	public Transform[] computerArray;
	public Transform[] fridgeArray;
	public Transform[] sinkArray;
	public Transform[] toiletArray;
	public Transform[] tvArray;

	// Start is called before the first frame update
	private void Start()
	{
        for (int i = 0; i < numberOfBeds; i++)
        {
            Instantiate(bedPrefab, bedArray[i].position, bedArray[i].rotation);
        }
        for (int i = 0; i < numberOfComputers; i++)
        {
            Instantiate(computerPrefab, computerArray[i].position, computerArray[i].rotation);
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
        for (int i = 0; i < numberOfTvs; i++)
        {
            Instantiate(tvPrefab, tvArray[i].position, tvArray[i].rotation);
        }
    }
}
