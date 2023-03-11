using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public int bladder;
    public int boredom;
    public int energy;
    public int hunger;
    public int money;
    public int thirst;

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

    // The NPC eats to slate their hunger.
    public IEnumerator Eat()
    {
        timeInSeconds = 10;

        if (withinRangeOfTarget)
        {
            hunger += 100;
            money -= 10;
            if (hunger > 100)
            {
                hunger = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    // The NPC uses the toilet to empty their bladder.
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

    // The NPC uses the bed to refill their energy.
    public IEnumerator Sleep()
    {
        timeInSeconds = 80;

        if (withinRangeOfTarget)
        {
            energy += 100;
            money -= 20;
            if (energy > 100)
            {
                energy = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    public IEnumerator WatchTv()
    {
        timeInSeconds = 10;

        if (withinRangeOfTarget)
        {
            boredom += 50;
            money -= 5;
            if (boredom > 100)
            {
                boredom = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    // The NPC uses the computer to earn money.
    public IEnumerator Work()
    {
        timeInSeconds = 10;

        if (withinRangeOfTarget)
        {
            money += 10;
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    // The NPC moves to the nearest targeted station.
    void MoveToTarget()
    {
        distanceToNearestStation = Mathf.Infinity;
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

        // Determines what the nearest targeted GameObject is
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
