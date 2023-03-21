using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityPreset : MonoBehaviour
{
    public float bladderWeight;
    public float boredomWeight;
    public float energyWeight;
    public float hungerWeight;
    public float thirstWeight;
    public int minMoneyThreshold;

    public PersonalityPreset(float bladder, float boredom, float energy, float hunger, float thirst, int minMoney)
    {
        bladderWeight = bladder;
        boredomWeight = boredom;
        energyWeight = energy;
        hungerWeight = hunger;
        thirstWeight = thirst;
        minMoneyThreshold = minMoney;
    }
}
