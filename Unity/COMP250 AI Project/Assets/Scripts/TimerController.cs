using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

/// <summary>
/// Class <c>TimerController</c> handles timers, mainly the timer for Needs decay.
/// </summary>
public class TimerController : MonoBehaviour
{
    int timerLength; // Length of the timer.
    int timerSpeed; // Speed of the timer in seconds.
    Timer timer; // The timer for Needs decay.

    NPCController npc; // Reference to the attached NPCController script.

    /// <summary>
    /// Method <c>Start</c> is called before the first frame.
    /// </summary>
    void Start()
    {
        timerSpeed = 1; //Timer moves by this value per second.
        timerLength = 100; //The total timer value.
        npc = GetComponent<NPCController>();

        // This timer will repeat indefinitely, and it ticks every second.
        timer = new Timer(timerSpeed * timerLength);
        timer.AutoReset = true;
        timer.Enabled = true;

        // Calls UpdateBars() on a regular interval. Allows instant updating of the UI progress bars.
        // The three parameters are the function to call, the initial delay in seconds, and the interval delay in seconds.
        InvokeRepeating("UpdateBars", 1f, 1f);
    }

    /// <summary>
    /// Method <c>UpdateBars</c> updates the UI progress bars in realtime.
    /// </summary>
    void UpdateBars()
    {
        npc.bladder.UpdateBar(npc.bladder.bar, npc.bladder.currentValue -= npc.bladder.decreaseSpeed);
        npc.boredom.UpdateBar(npc.boredom.bar, npc.boredom.currentValue -= npc.boredom.decreaseSpeed);
        npc.energy.UpdateBar(npc.energy.bar, npc.energy.currentValue -= npc.energy.decreaseSpeed);
        npc.hunger.UpdateBar(npc.hunger.bar, npc.hunger.currentValue -= npc.hunger.decreaseSpeed);
        npc.thirst.UpdateBar(npc.thirst.bar, npc.thirst.currentValue -= npc.thirst.decreaseSpeed);
    }
}
