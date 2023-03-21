using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PersonalityController</c> handles the functions relating to generating personalities and Needs weights. 
/// It handles all the logic behind what an NPC AI decides to do next.
/// </summary>
public class PersonalityController : MonoBehaviour
{
    bool needsMoney; // Determines if the NPC needs to Work() before satisfying needs.
    float bladderReward; // The reward value for choosing to do EmptyBladder() from the NPCController script.
    float bladderWeight; // The weight that skews the reward value determination in CalcReward().
    float boredomReward; // The reward value for choosing to do WatchTv() from the NPCController script.
    float boredomWeight; // The weight that skews the reward value determination in CalcReward().
    float energyReward; // The reward value for choosing to do Sleep() from the NPCController script.
    float energyWeight; // The weight that skews the reward value determination in CalcReward().
    float highestReward; // The highest reward value.
    float hungerReward; // The reward value for choosing to do Eat() from the NPCController script.
    float hungerWeight; // The weight that skews the reward value determination in CalcReward().
    float maxWeight; // The maximum weight value.
    float minWeight; // The minimum weight value.
    float randomizationFactor; // The randomization factor for randomizing choices based on reward values. 1.05 by default.
    float temp; // Used for temporarily holding a float in CalcReward. Makes code easier to read.
    float thirstReward; // The reward value for choosing to do Drink() from the NPCController script.
    float thirstWeight; // The weight that skews the reward value determination in CalcReward().
    float totalWeight; // The total weight of all weight values combined.
    int minMoneyThreshold; // The minimum money threshold for an NPC AI determining that they need to Work().
    int moneyNeededPerDay; // A placeholder value that determines a rough estimate for what the minMoneyThreshold should be based on default price values of satisfying Needs.

    NPCController npcController; // A reference to the attached NPCController script.
    PersonalityPreset personalityPreset; // A reference to the attached PersonalityPreset script.

    /// <summary>
    /// Method <c>GeneratePersonality</c> randomly generates weights for each Need.
    /// </summary>
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

    /// <summary>
    /// Method <c>GeneratePersonalityFromPreset</c> generates a personality according to the PersonalityPreset script's set values.
    /// </summary>
    /// <param name="bladder"></param> is the set value for the bladder Need.
    /// <param name="boredom"></param> is the set value for the boredom Need.
    /// <param name="energy"></param> is the set value for the energy Need.
    /// <param name="hunger"></param> is the set value for the hunger Need.
    /// <param name="thirst"></param> is the set value for the thirst Need.
    /// <param name="minMoney"></param> is the set value for the minimum money threshold.
    void GeneratePersonalityFromPreset(float bladder, float boredom, float energy, float hunger, float thirst, int minMoney)
    {
        bladderWeight = bladder;
        boredomWeight = boredom;
        energyWeight = energy;
        hungerWeight = hunger;
        thirstWeight = thirst;
        maxWeight = 1f;
        minMoneyThreshold = minMoney;
        minWeight = 0.1f;

        // This ensures that user input remains within bounds of the weightings.
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

    /// <summary>
    /// Method <c>CalcReward</c> determines the reward value for each available action by taking the difference of the max value and current value multiplied by the reward weight.
    /// This value is then further modified with a randomization factor. The further away the randomization factor is from 1, the greater the fluctuation will be.
    /// Adjusting this too far will render the weightings essentially irrelevant.
    /// </summary>
    /// <param name="need"></param>
    /// <param name="rewardWeight"></param>
    /// <param name="randomizationFactor"></param>
    /// <returns></returns>
    float CalcReward(NPCController.Need need, float rewardWeight, float randomizationFactor)
    {
        temp = ((need.maxValue - need.currentValue) * rewardWeight);

        if (temp * randomizationFactor < temp)
        {
            return Random.Range(temp * randomizationFactor, temp);
        }
        else
        {
            return Random.Range(temp, temp * randomizationFactor);
        }      
    }

    /// <summary>
    /// Method <c>Start</c> is called at the beginning of the program.
    /// </summary>
    void Start()
    {
        moneyNeededPerDay = 60; // Based off eating 3X per day, sleeping 1X per day, and watching TV 2X per day.
        npcController = GetComponent<NPCController>();
        minMoneyThreshold = moneyNeededPerDay; // Set by default to the minimum money needed per day.
        personalityPreset = GetComponent<PersonalityPreset>();
        randomizationFactor = 1.05f;

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

    /// <summary>
    /// Method <c>Update</c> is called every frame.
    /// </summary>
    void Update()
    {
        if (!npcController.isBusy) 
        {
            Debug.Log("Choosing");
            ChooseNextAction();
        }
    }

    /// <summary>
    /// Method <c>ChooseNextAction</c> sets the NPC's target based on reward values.
    /// </summary>
    void ChooseNextAction()
    {
        npcController.isBusy = true;
        npcController.withinRangeOfTarget = false;
        bladderReward = CalcReward(npcController.bladder, bladderWeight, randomizationFactor);
        boredomReward = CalcReward(npcController.boredom, boredomWeight, randomizationFactor);
        energyReward = CalcReward(npcController.energy, energyWeight, randomizationFactor);
        hungerReward = CalcReward(npcController.hunger, hungerWeight, randomizationFactor);
        thirstReward = CalcReward(npcController.thirst, thirstWeight, randomizationFactor);
        highestReward = Mathf.Max(bladderReward, boredomReward, energyReward, hungerReward, thirstReward);


        // Checks if NPC needs to work to earn money before satisfying needs.
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

        // If the NPC is not within range of the target, it moves there.
        if (!npcController.withinRangeOfTarget)
        {
            Debug.Log("Moving");
            npcController.MoveToTarget();
        }
    }
}
