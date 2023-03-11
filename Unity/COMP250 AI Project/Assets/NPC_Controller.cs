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
    public bool withinRangeOfTarget = false;
    public int timeInSeconds;


    void Start ()
    {
        this.enabled = true;
    }

    // The NPC drinks to slate their thirst.
    public IEnumerator Drink()
    {
        timeInSeconds = 3;

        if (withinRangeOfTarget)
        {
            thirst += 10;
            if (thirst > 100)
            {
                thirst = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    public IEnumerator Eat()
    {
        timeInSeconds = 10;

        if (withinRangeOfTarget)
        {
            hunger += 100;
            if (hunger > 100)
            {
                hunger = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    public IEnumerator EmptyBladder()
    {
        timeInSeconds = 5;

        if (withinRangeOfTarget)
        {
            bladder += 100;
            if (bladder > 100)
            {
                bladder = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    void SlateBladder()
    {
        distanceToNearestStation = Mathf.Infinity;
        target = "Toilet";
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

        // Determines what the nearest Toilet GameObject is
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

    void SlateHunger()
    {
        distanceToNearestStation = Mathf.Infinity;
        target = "Fridge";
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

        // Determines what the nearest Fridge GameObject is
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
