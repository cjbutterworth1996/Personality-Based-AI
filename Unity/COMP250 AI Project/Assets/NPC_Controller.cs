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

    void Drink()
    {
        distanceToNearestStation = Mathf.Infinity;
        target = "sink";
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

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
