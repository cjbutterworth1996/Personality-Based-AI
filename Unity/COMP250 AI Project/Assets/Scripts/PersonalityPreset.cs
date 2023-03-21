using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PersonalityPreset</c> provides values for overriding randomly generated values in the PersonalityController script.
/// </summary>
public class PersonalityPreset : MonoBehaviour
{
    public float bladderWeight; // Preset bladder weight.
    public float boredomWeight; // Preset boredom weight.
    public float energyWeight; // Preset energy weight.
    public float hungerWeight; // Preset hunger weight.
    public float thirstWeight; // Preset thirst weight.
    public int minMoneyThreshold; // Preset minimum money.
}
