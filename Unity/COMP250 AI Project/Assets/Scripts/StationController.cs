using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>StationController</c> is used to control the NPC's potential targets to interact with.
/// It also handles spawning for instantiating prefab targets.
/// </summary>
public class StationController : MonoBehaviour
{
	public GameObject bedPrefab; //Prefab bed object.
	public GameObject computerPrefab; //Prefab computer object.
    public GameObject fridgePrefab; //Prefab fridge object.
    public GameObject sinkPrefab; //Prefab sink object.
    public GameObject toiletPrefab; //Prefab toilet object.
    public GameObject tvPrefab; //Prefab TV object.
    public int numberOfBeds; //Number of beds being spawned.
    public int numberOfComputers; //Number of computers being spawned.
    public int numberOfFridges; //Number of fridges being spawned.
    public int numberOfSinks; //Number of sinks being spawned.
    public int numberOfToilets; //Number of toilets being spawned.
    public int numberOfTvs; //Number of TVs being spawned.
    public Transform[] bedArray; // Array of bed spawn points in the scene.
	public Transform[] computerArray; // Array of computer spawn points in the scene.
    public Transform[] fridgeArray; // Array of fridge spawn points in the scene.
    public Transform[] sinkArray; // Array of sink spawn points in the scene.
    public Transform[] toiletArray; // Array of toilet spawn points in the scene.
    public Transform[] tvArray; // Array of TV spawn points in the scene.

    /// <summary>
    /// Method <c>Start</c> is called before the first frame.
    /// </summary>
    private void Start()
	{
        // This instantiates all of the specified prefabs given the number of each prefab and array of specified prefab spawn points.
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
