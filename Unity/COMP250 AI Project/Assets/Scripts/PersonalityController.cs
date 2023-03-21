using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PersonalityController</c> handles the functions relating to generating personalities and Needs weights. 
/// It handles all the logic behind what an NPC AI decides to do next.
/// </summary>
public class PersonalityController : MonoBehaviour
{
    float bladderWeight;
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
    public int minMoneyThreshold;
    public float randomizationFactor;
    public float minWeight;
    public float maxWeight;
    public float totalWeight;
    public int moneyNeededPerDay;
    public NPCController npcController;
    public bool needsMoney;
    public PersonalityPreset personalityPreset;

    /// <summary>
    /// Method <c>PersonalityController</c> instantiates a PersonalityController.
    /// </summary>
    /// <param name="bladder"></param>
    /// <param name="boredom"></param>
    /// <param name="energy"></param>
    /// <param name="hunger"></param>
    /// <param name="thirst"></param>
    /// <param name="minMoney"></param>
    public PersonalityController(float bladder, float boredom, float energy, float hunger, float thirst, int minMoney)
    {
        bladderWeight = bladder;
        boredomWeight = boredom;
        energyWeight = energy;
        hungerWeight = hunger;
        thirstWeight = thirst;
        minMoneyThreshold = minMoney;
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

    void GeneratePersonalityFromPreset(float bladder, float boredom, float energy, float hunger, float thirst, int minMoney)
    {
        minWeight = 0.1f;
        maxWeight = 1f;
        bladderWeight = bladder;
        boredomWeight = boredom;
        energyWeight = energy;
        hungerWeight = hunger;
        thirstWeight = thirst;
        minMoneyThreshold = minMoney;

        // This ensures that user input remains in bounds of the weightings
        if(bladderWeight > maxWeight)
        {
            bladderWeight = maxWeight;
        }
        if (boredomWeight > maxWeight)
        {
            boredomWeight = maxWeight;
        }
        if (energyWeight > maxWeight)
        {
            energyWeight = maxWeight;
        }
        if (hungerWeight > maxWeight)
        {
            hungerWeight = maxWeight;
        }
        if (thirstWeight > maxWeight)
        {
            thirstWeight = maxWeight;
        }
        if (bladderWeight < minWeight)
        {
            bladderWeight = minWeight;
        }
        if (boredomWeight < minWeight)
        {
            boredomWeight = minWeight;
        }
        if (energyWeight < minWeight)
        {
            energyWeight = minWeight;
        }
        if (hungerWeight < minWeight)
        {
            hungerWeight = minWeight;
        }
        if (bladderWeight < minWeight)
        {
            bladderWeight = minWeight;
        }
        

        // Normalizes all of the weights to add up to 1. This is to ensure all of the probabilities add up to 100%.
        totalWeight = bladderWeight + boredomWeight + energyWeight + hungerWeight + thirstWeight;
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
        minMoneyThreshold = moneyNeededPerDay; // Set by default to the minimum money needed per day.
        personalityPreset = GetComponent<PersonalityPreset>();

        // If the PersonalityPreset script is attached to the NPC, it will override the random generation of personality weights.
        if(personalityPreset != null)
        {
            GeneratePersonalityFromPreset(personalityPreset.bladderWeight, personalityPreset.boredomWeight, personalityPreset.energyWeight, personalityPreset.hungerWeight, personalityPreset.thirstWeight, personalityPreset.minMoneyThreshold);
        }
        else
        {
            Debug.Log("Random Personality Generated");
            GeneratePersonality(); // This gets called if there is no PersonalityPreset script attached to the NPC.
        }
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
        needsMoney = (npcController.money < minMoneyThreshold);

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
    }
}
