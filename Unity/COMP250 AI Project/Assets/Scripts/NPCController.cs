using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCController : MonoBehaviour
{
    public int money;
    public string target;
    public float speed;
    float distanceToNearestStation;
    float distance;
    GameObject[] targetObjects;
    GameObject closestTarget = null;
    public bool withinRangeOfTarget = false;
    public int timeInSeconds;

    public class Need
    {
        public int maxValue;
        public int currentValue;
        public int decreaseSpeed;

        public Need(int max, int current, int speed)
        {
            maxValue = max;
            currentValue = current;
            decreaseSpeed = speed;
        }

        public void DecreaseNeed()
        {
            currentValue -= decreaseSpeed;

            if (currentValue <= 0)
            {
                // Implement death script
            }
        }
    }

    public Need bladder;
    public Need boredom;
    public Need energy;
    public Need hunger;
    public Need thirst;

    void Start ()
    {
        this.enabled = true;
        bladder = new Need(100, 100, 1);
        boredom = new Need(100, 100, 1);
        energy = new Need(100, 100, 1);
        hunger = new Need(100, 100, 1);
        thirst = new Need(100, 100, 1);

    }

    // The NPC drinks to slate their thirst.
    public IEnumerator Drink()
    {
        timeInSeconds = 1;

        if (withinRangeOfTarget)
        {
            thirst.currentValue += 10;
            if (thirst.currentValue > 100)
            {
                thirst.currentValue = 100;
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
            hunger.currentValue += 100;
            money -= 10;
            if (hunger.currentValue > 100)
            {
                hunger.currentValue = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    // The NPC uses the toilet to empty their bladder.
    public IEnumerator EmptyBladder()
    {
        timeInSeconds = 2;

        if (withinRangeOfTarget)
        {
            bladder.currentValue += 100;
            if (bladder.currentValue > 100)
            {
                bladder.currentValue = 100;
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
            energy.currentValue += 100;
            money -= 20;
            if (energy.currentValue > 100)
            {
                energy.currentValue = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
        }
    }

    public IEnumerator WatchTv()
    {
        timeInSeconds = 10;

        if (withinRangeOfTarget)
        {
            boredom.currentValue += 50;
            money -= 5;
            if (boredom.currentValue > 100)
            {
                boredom.currentValue = 100;
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
