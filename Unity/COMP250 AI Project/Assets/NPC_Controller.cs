using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public int thirst;
    public int hunger;
    public int bladder;
    public int energy;
    public int boredom;

    public string target;
    public float speed;
    float distanceToNearestStation;
    float distance;
    GameObject[] targetObjects;
    GameObject closestTarget = null;


    void Start ()
    {
        this.enabled = true;
    }

    // This increases the Thirst value by determining the nearest Sink GameObject and then moving to it. A collision sphere then triggers the Drink function.
    void SlateThirst()
    {
        distanceToNearestStation = Mathf.Infinity;
        target = "Sink";
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

        // Determines what the nearest Sink GameObject is
        foreach (GameObject targetObject in targetObjects)
        {
            distance = Vector3.Distance(transform.position, targetObject.transform.position);

            if (distance < distanceToNearestStation) 
            {
                distanceToNearestStation = distance;
                closestTarget = targetObject;
            }
        }

        if (closestTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
        }
    }
}
