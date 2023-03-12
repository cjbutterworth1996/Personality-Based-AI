using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public int timerSpeed;
    private Timer timer;
    private int timerLength;
    private NPCController npc;
    private UIController ui;

    void Start()
    {
        timerSpeed = 1;
        timerLength = 100;
        npc = GetComponent<NPCController>();

        // This timer will repeat indefinitely, and it ticks every second.
        timer = new Timer(timerSpeed * timerLength);
        timer.AutoReset = true;
        timer.Enabled = true;

        // Calls UpdateBars() on a regular interval. Allows instant updating of the UI progress bars.
        // The three parameters are the function to call, the initial delay in seconds, and the interval delay in seconds.
        InvokeRepeating("UpdateBars", 1f, 1f);
    }

    // Updates the NPC's Needs ProgressBars based on their decreaseSpeed.
    void UpdateBars()
    {
        npc.bladder.UpdateBar(npc.bladder.bar, npc.bladder.currentValue -= npc.bladder.decreaseSpeed);
        npc.boredom.UpdateBar(npc.boredom.bar, npc.boredom.currentValue -= npc.boredom.decreaseSpeed);
        npc.energy.UpdateBar(npc.energy.bar, npc.energy.currentValue -= npc.energy.decreaseSpeed);
        npc.hunger.UpdateBar(npc.hunger.bar, npc.hunger.currentValue -= npc.hunger.decreaseSpeed);
        npc.thirst.UpdateBar(npc.thirst.bar, npc.thirst.currentValue -= npc.thirst.decreaseSpeed);
    }
}
