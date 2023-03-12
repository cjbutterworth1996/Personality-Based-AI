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
        timer.Elapsed += DecreaseNeeds;
        timer.AutoReset = true;
        timer.Enabled = true;

        InvokeRepeating("UpdateBars", 1f, 1f);
    }

    void DecreaseNeeds(object sender, ElapsedEventArgs e)
    {
        StartCoroutine(DecreaseNeed(npc.bladder));
        StartCoroutine(DecreaseNeed(npc.boredom));
        StartCoroutine(DecreaseNeed(npc.energy));
        StartCoroutine(DecreaseNeed(npc.hunger));
        StartCoroutine(DecreaseNeed(npc.thirst));
    }

    // Decreases each needs bar at a constant speed. By default this is by 1 every 1 second.
    IEnumerator DecreaseNeed(NPCController.Need need)
    {
        while (need.currentValue > 0)
        {
            need.currentValue -= need.decreaseSpeed;
            Debug.Log("need.currentValue = " + need.currentValue);
            need.UpdateBar(need.bar, need.currentValue);

            if (need.currentValue <= 0)
            {
                // Implement death script
            }

            yield return new WaitForSeconds(need.decreaseSpeed);
        }
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
