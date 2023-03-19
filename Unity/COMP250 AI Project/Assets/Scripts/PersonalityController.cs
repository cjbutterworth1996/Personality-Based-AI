using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityController : MonoBehaviour
{
    public float bladderWeight;
    public float boredomWeight;
    public float energyWeight;
    public float hungerWeight;
    public float thirstWeight;
    public float bladderReward;
    public float boredomReward;
    public float energyReward;
    public float hungerReward;
    public float thirstReward;
    public float highestReward;
    public float minMoneyThreshold;
    public float maxMoneyThreshold;
    public float randomizationFactor;
    public float minWeight;
    public float maxWeight;
    public float totalWeight;
    public int moneyNeededPerDay;
    public NPCController npcController;
    public bool needsMoney;

    public PersonalityController(float bladder, float boredom, float energy, float hunger, float thirst, float minMoney, float maxMoney)
    {
        bladderWeight = bladder;
        boredomWeight = boredom;
        energyWeight = energy;
        hungerWeight = hunger;
        thirstWeight = thirst;
        minMoneyThreshold = minMoney;
        maxMoneyThreshold = maxMoney;
    }

    void GeneratePersonality ()
    {
        // This sets the min and max weight for each need.
        minWeight = 0.1f;
        maxWeight = 1f;

        // This generates a random weight for each need within the set parameters.
        bladderWeight = Random.Range(minWeight, maxWeight);
        boredomWeight = Random.Range(minWeight, maxWeight);
        energyWeight = Random.Range(minWeight, maxWeight);
        hungerWeight = Random.Range(minWeight, maxWeight);
        thirstWeight = Random.Range(minWeight, maxWeight);

        // Normalizes all of the weights to add up to 1. This is to ensure all of the probabilities add up to 100%.
        totalWeight = bladderWeight+ boredomWeight + energyWeight + hungerWeight + thirstWeight;
        bladderWeight /= totalWeight;
        boredomWeight /= totalWeight;
        energyWeight /= totalWeight;
        hungerWeight /= totalWeight;
        thirstWeight /= totalWeight;
    }

    // Creates a reward for fulfilling a need based on distance from maxValue and the NPC's personality-set rewardWeight.
    float CalcReward(NPCController.Need need, float rewardWeight)
    {
        return (need.maxValue - need.currentValue) * rewardWeight;
    }

    void Start()
    {
        randomizationFactor = 0.5f;
        moneyNeededPerDay = 60; // Based off eating 3X per day, sleeping 1X per day, and watching TV 2X per day.
        npcController = GetComponent<NPCController>();
        GeneratePersonality(); // IF THERE IS NO PERSONALITY TAGS
    }

    void Update()
    {
        if (!npcController.isBusy) 
        {
            Debug.Log("Choosing");
            ChooseNextAction();
        }
    }

    void ChooseNextAction()
    {
        npcController.isBusy = true;
        npcController.withinRangeOfTarget = false;
        bladderReward = CalcReward(npcController.bladder, bladderWeight);
        boredomReward = CalcReward(npcController.boredom, boredomWeight);
        energyReward = CalcReward(npcController.energy, energyWeight);
        hungerReward = CalcReward(npcController.hunger, hungerWeight);
        thirstReward = CalcReward(npcController.thirst, thirstWeight);
        highestReward = Mathf.Max(bladderReward, boredomReward, energyReward, hungerReward, thirstReward);


        // Check if NPC needs to work to earn money before satisfying needs.
        needsMoney = (npcController.money < minMoneyThreshold || npcController.money > maxMoneyThreshold);

        if (needsMoney)
        {
            npcController.target = "Computer";
        }
        else if (highestReward == bladderReward)
        {
            npcController.target = "Toilet";
        }
        else if (highestReward == boredomReward)
        {
            npcController.target = "TV";
        }
        else if (highestReward == energyReward)
        {
            npcController.target = "Bed";
        }
        else if (highestReward == hungerReward)
        {
            npcController.target = "Fridge";
        }
        else if (highestReward == thirstReward)
        {
            npcController.target = "Sink";
        }

        Debug.Log("New Target = " + npcController.target);

        if (!npcController.withinRangeOfTarget)
        {
            Debug.Log("Moving");
            npcController.MoveToTarget();
        }
        else
        {
            if (npcController.target == "Toilet")
            {
                StartCoroutine(npcController.EmptyBladder());
            }
            else if (npcController.target == "TV")
            {
                StartCoroutine(npcController.WatchTv());
            }
            else if (npcController.target == "Bed")
            {
                StartCoroutine(npcController.Sleep());
            }
            else if (npcController.target == "Fridge")
            {
                StartCoroutine(npcController.Eat());
            }
            else if (npcController.target == "Sink")
            {
                StartCoroutine(npcController.Drink());
            }
        }
    }
}
