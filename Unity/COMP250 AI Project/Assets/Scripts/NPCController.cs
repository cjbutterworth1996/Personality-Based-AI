using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>NPCController</c> controls all NPC AI behaviour.
/// </summary>
public class NPCController : MonoBehaviour
{
    public bool isBusy; // Determines if NPC should take another action.
    public bool withinRangeOfTarget; // Determines if NPC is within range of their target.
    public float speed; //Used in StepTowardsTarget() to determine how fast the NPC should move towards their target.
    public int money; //NPC's current money.
    public string target; //NPC's current target.

    bool deathEnabled;
    float distance; //Used in calculating distances from NPC to stations.
    float distanceThreshold; //Used to determine when an NPC is close enough to a station to begin using it.
    float distanceToNearestStation; //The distance from the NPC to the nearest target station.
    GameObject[] targetObjects; //Array of all possible target objects.
    GameObject closestTarget; //The nearest GameObject with the NPC's target tag.
    int timeInSeconds; //Used to determine how long each possible action should take the NPC to complete.

    SceneController sceneController; // A reference to the nearest SceneController, used for handling NPC death.
    UIController uiController; // A reference to the nearest UIController, used for updating UI elements.

    /// <summary>
    /// Class <c>Need</c> handles all of the AI NPC's needs bars. These are visualized as progress bars, but can be any integer variables that tick down over time.
    /// </summary>
    public class Need
    {
        public int currentValue;
        public int decreaseSpeed;
        public int maxValue;
        public ProgressBar bar;

        public NPCController attachedNPC;

        /// <summary>
        /// Method <c>Need</c> instantiates a Need object.
        /// </summary>
        /// <param name="max"></param> is the maximum value for the Need.
        /// <param name="current"></param> is the current value for the Need.
        /// <param name="speed"></param> is the speed of decay in seconds for the Need.
        /// <param name="barName"></param> is the name of the progress bar to reference in the UIController.
        /// <param name="uiController"></param> is the UIController that contains said progress bars.
        /// <param name="npc"></param> is the NPCController that the Need is attached to.
        public Need(int max, int current, int speed, string barName, UIController uiController, NPCController npc)
        {
            attachedNPC = npc;
            bar = uiController.uiDoc.rootVisualElement.Q<ProgressBar>(barName);
            currentValue = current;
            decreaseSpeed = speed;
            maxValue = max;
        }

        /// <summary>
        /// Method <c>UpdateBar</c> updates a progress bar in the UIController. It also calls the Death() function if any bar reaches zero and death is enabled.
        /// </summary>
        /// <param name="bar"></param> is the name of the progress bar being referenced in the UIController.
        /// <param name="updateAmount"></param> is the value that the progress bar is being updated to reflect.
        public void UpdateBar(ProgressBar bar, int updateAmount)
        {
            bar.value = updateAmount;

            // If any need reaches zero and death is enabled, the NPC method Death() is called.
            if (bar.value <= 0 && attachedNPC.deathEnabled)
            {
                attachedNPC.Death();
            }
        }
    }

    // Declaring the core needs for the demo.
    public Need bladder;
    public Need boredom;
    public Need energy;
    public Need hunger;
    public Need thirst;

    /// <summary>
    /// Method <c>Start</c> is called at the beginning of the program.
    /// </summary>
    void Start ()
    {
        this.enabled = true; //Ensures the script is enabled.
        uiController = FindObjectOfType<UIController>();
        bladder = new Need(100, 100, 1, "BladderBar", uiController, this);
        boredom = new Need(100, 100, 1, "BoredomBar", uiController, this);
        energy = new Need(100, 100, 1, "EnergyBar", uiController, this);
        hunger = new Need(100, 100, 1, "HungerBar", uiController, this);
        thirst = new Need(100, 100, 1, "ThirstBar", uiController, this);

        closestTarget = null;
        deathEnabled = false;
        distanceThreshold = 2f;
        isBusy = false;
        money = 100;
        withinRangeOfTarget = false;
    }

    /// <summary>
    /// Method <c>Death</c> calls the SceneController to reset the scene.
    /// </summary>
    void Death()
    {
        Debug.Log("Died");
        sceneController.SceneReset();
    }

    /// <summary>
    /// Method <c>Drink</c> satiates the NPC's thirst Need.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
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

    /// <summary>
    /// Method <c>Eat</c> satiates the NPC's hunger Need.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
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

    /// <summary>
    /// Method <c>EmptyBladder</c> satiates the NPC's bladder Need.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
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

    /// <summary>
    /// Method <c>Sleep</c> satiates the NPC's energy Need.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
    public IEnumerator Sleep()
    {
        timeInSeconds = 10;
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

    /// <summary>
    /// Method <c>WatchTv</c> satiates the NPC's boredom Need.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
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

    /// <summary>
    /// Method <c>Work</c> increases the NPC's available money.
    /// </summary>
    /// <returns>Does not return anything, waits for timeInSeconds.</returns>
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

    /// <summary>
    /// Method <c>MoveToTarget</c> finds the nearest GameObject with the tag that matches the NPC's target variable. If that is a non-null value, it begins the coroutine for stepping the NPC towards said nearest GameObject.
    /// </summary>
    public void MoveToTarget()
    {
        distanceToNearestStation = Mathf.Infinity;
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(target);

        // Determines what the nearest targeted GameObject is.
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

    /// <summary>
    /// Method <c>StepTowardsTarget</c> is a coroutine that moves the NPC towards their target over a specified period of time (speed * Time.deltaTime).
    /// This is to ensure the NPC does not appear to teleport to their target.
    /// </summary>
    /// <param name="target"></param> is the target that the NPC is moving towards.
    /// <returns></returns>
    IEnumerator StepTowardsTarget(string target)
    {
        while (Vector3.Distance(transform.position, closestTarget.transform.position) > distanceThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
            yield return null;
        }

        withinRangeOfTarget = true;
        DoNearestAction(target);
    }

    /// <summary>
    /// Method <c>DoNearestAction</c> starts the corresponding coroutine depending on what station the NPC moved to.
    /// </summary>
    /// <param name="target"></param> is the target that the NPC moved to.
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
