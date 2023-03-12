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

    void Start()
    {
        timer = new Timer(decreaseSpeed * timerLength);
        timer.Elapsed += DecreaseNeeds;
        timer.AutoReset = false;
        timer.Enabled = true;
        npc = GetComponent<NPCController>();
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

            if (need.currentValue <= 0)
            {
                // Implement death script
            }

            yield return new WaitForSeconds(need.decreaseSpeed);
        }
    }
}
