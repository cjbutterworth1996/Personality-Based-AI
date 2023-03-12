using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public int needsMin = 0;
    public int needsMax = 100;
    public int decreaseSpeed = 1;
    private Timer timer;
    private int timerLength = 100;
    private NPCController npc;
    private UIController ui;

    void Start()
    {
        npc = GetComponent<NPCController>();
        timer = new Timer(decreaseSpeed * timerLength);
        timer.AutoReset = true;
        timer.Enabled = true;

        InvokeRepeating("UpdateBars", 1f, 1f);
    }

    void UpdateBars()
    {
        npc.bladder.UpdateBar(npc.bladder.bar, npc.bladder.currentValue -= npc.bladder.decreaseSpeed);
        npc.boredom.UpdateBar(npc.boredom.bar, npc.boredom.currentValue -= npc.boredom.decreaseSpeed);
        npc.energy.UpdateBar(npc.energy.bar, npc.energy.currentValue -= npc.energy.decreaseSpeed);
        npc.hunger.UpdateBar(npc.hunger.bar, npc.hunger.currentValue -= npc.hunger.decreaseSpeed);
        npc.thirst.UpdateBar(npc.thirst.bar, npc.thirst.currentValue -= npc.thirst.decreaseSpeed);
    }
}
