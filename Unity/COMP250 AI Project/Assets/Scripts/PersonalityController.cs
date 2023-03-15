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
    public float minMoneyThreshold;
    public float maxMoneyThreshold;
    public float randomizationFactor;
    public int moneyNeededPerDay;
    public NPCController npcController;

    void PersonalityController(float bladder, float boredom, float energy, float hunger, float thirst, float minMoney, float maxMoney)
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

    }

    // Creates a reward for fulfilling a need based on distance from maxValue and the NPC's personality-set rewardWeight.
    float CalcReward(float NPCController.Need need, float rewardWeight)
    {
        return (need.maxValue - need.currentValue) * rewardWeight;
    }

    void Start()
    {
        randomizationFactor = 0.5f;
        moneyNeededPerDay = 60; // Based off eating 3X per day, sleeping 1X per day, and watching TV 2X per day.
        npcController = GetComponent<NPCController>();
    }

    void Update()
    {
        float rewardBladder = CalculateReward(bladderLevel, weightBladder);
        float rewardBoredom = CalculateReward(boredomLevel, weightBoredom);
        float rewardEnergy = CalculateReward(energyLevel, weightEnergy);
        float rewardHunger = CalculateReward(hungerLevel, weightHunger);
        float rewardThirst = CalculateReward(thirstLevel, weightThirst);

        // Check if NPC needs to work to earn money before satisfying needs.
        bool needsMoney = (money < minMoneyThreshold || money > maxMoneyThreshold);
        if (needsMoney)
        {
            npcController.target = "Computer";
            npcController.MoveToTarget();
            if(npcController.withinRangeOfTarget)
            {
                npcController.Work();
            }
        }

        float highestReward = Mathf.Max(rewardBladder, rewardBoredom, rewardEnergy, rewardHunger, rewardThirst);
        if (highestReward == rewardBladder)
        {
            PerformBladderAction(needsMoney);
        }
        else if (highestReward == rewardBoredom)
        {
            PerformBoredomAction(prioritizeFinances);
        }
        else if (highestReward == rewardEnergy)
        {
            PerformEnergyAction(prioritizeFinances);
        }
        else if (highestReward == rewardHunger)
        {
            PerformHungerAction(prioritizeFinances);
        }
        else if (highestReward == rewardThirst)
        {
            PerformThirstAction(prioritizeFinances);
        }
    }
}
