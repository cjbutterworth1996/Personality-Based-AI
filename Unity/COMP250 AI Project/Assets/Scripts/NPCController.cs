using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class NPCController : MonoBehaviour
{
    public int money;
    public string target;
    public float speed;
    float distanceToNearestStation;
    float distance;
    GameObject[] targetObjects;
    GameObject closestTarget;
    public bool withinRangeOfTarget;
    public bool isBusy;
    public int timeInSeconds;
    public UIController uiController;
    public SceneController sceneController;
    public PersonalityController personalityController;
    float distanceThreshold;
    string stationString;

    public class Need
    {
        public int maxValue;
        public int currentValue;
        public int decreaseSpeed;
        public ProgressBar bar;
        public NPCController attachedNPC;

        public Need(int max, int current, int speed, string barName, UIController uiController, NPCController npc)
        {
            maxValue = max;
            currentValue = current;
            decreaseSpeed = speed;
            bar = uiController.uiDoc.rootVisualElement.Q<ProgressBar>(barName);
            attachedNPC= npc;
        }

        public void UpdateBar(ProgressBar bar, int updateAmount)
        {
            bar.value = updateAmount;

            // If the NPC dies, the scene is reset.
            if (bar.value <= 0)
            {
                attachedNPC.sceneController = FindObjectOfType<SceneController>();
                attachedNPC.sceneController.SceneReset();
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
        uiController = FindObjectOfType<UIController>();
        bladder = new Need(100, 100, 1, "BladderBar", uiController, this);
        boredom = new Need(100, 100, 1, "BoredomBar", uiController, this);
        energy = new Need(100, 100, 1, "EnergyBar", uiController, this);
        hunger = new Need(100, 100, 1, "HungerBar", uiController, this);
        thirst = new Need(100, 100, 1, "ThirstBar", uiController, this);
        withinRangeOfTarget = false;
        closestTarget= null;
        isBusy = false;
        personalityController = GetComponent<PersonalityController>();
        distanceThreshold = 2f;
        money = 100;
    }

    public void Death()
    {
        Debug.Log("Died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // The NPC drinks to slate their thirst.
    public IEnumerator Drink()
    {
        timeInSeconds = 1;
        Debug.Log("Drinking");

        if (withinRangeOfTarget)
        {
            thirst.currentValue += 10;
            if (thirst.currentValue > 100)
            {
                thirst.currentValue = 100;
            }
            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    // The NPC eats to slate their hunger.
    public IEnumerator Eat()
    {
        timeInSeconds = 10;
        Debug.Log("Eating");

        if (withinRangeOfTarget)
        {
            hunger.currentValue += 100;
            money -= 10;
            uiController.UpdateMoney(money);

            if (hunger.currentValue > 100)
            {
                hunger.currentValue = 100;
            }

            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    // The NPC uses the toilet to empty their bladder.
    public IEnumerator EmptyBladder()
    {
        timeInSeconds = 2;
        Debug.Log("Pooping");

        if (withinRangeOfTarget)
        {
            bladder.currentValue += 100;

            if (bladder.currentValue > 100)
            {
                bladder.currentValue = 100;
            }

            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    // The NPC uses the bed to refill their energy.
    public IEnumerator Sleep()
    {
        timeInSeconds = 80;
        Debug.Log("Sleeping");

        if (withinRangeOfTarget)
        {
            energy.currentValue += 100;
            money -= 20;
            uiController.UpdateMoney(money);

            if (energy.currentValue > 100)
            {
                energy.currentValue = 100;
            }

            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    public IEnumerator WatchTv()
    {
        timeInSeconds = 10;
        Debug.Log("Watching TV");

        if (withinRangeOfTarget)
        {
            boredom.currentValue += 50;
            money -= 5;
            uiController.UpdateMoney(money);

            if (boredom.currentValue > 100)
            {
                boredom.currentValue = 100;
            }

            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    // The NPC uses the computer to earn money.
    public IEnumerator Work()
    {
        timeInSeconds = 10;
        Debug.Log("Working");

        if (withinRangeOfTarget)
        {
            money += 10;
            uiController.UpdateMoney(money);

            yield return new WaitForSeconds(timeInSeconds);
            isBusy = false;
        }
    }

    // The NPC moves to the nearest targeted station.
    public void MoveToTarget()
    {
        Debug.Log("Moving");
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
            StartCoroutine(StepTowardsTarget(target));
        }
    }

    IEnumerator StepTowardsTarget(string target)
    {
        while (Vector3.Distance(transform.position, closestTarget.transform.position) > distanceThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
            yield return null;
        }

        withinRangeOfTarget = true;
        DoNearestAction(target);
        Debug.Log("Reached target");
    }

    public void DoNearestAction(string target)
    {
        if (target == "Toilet")
        {
            StartCoroutine(EmptyBladder());
        }
        else if (target == "TV")
        {
            StartCoroutine(WatchTv());
        }
        else if (target == "Bed")
        {
            StartCoroutine(Sleep());
        }
        else if (target == "Fridge")
        {
            StartCoroutine(Eat());
        }
        else if (target == "Sink")
        {
            StartCoroutine(Drink());
        }
    }
}
