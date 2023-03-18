using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private NPCController npc;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided");
        if (collider.gameObject.tag == "NPC")
        {
            npc = collider.gameObject.GetComponent<NPCController>();

            if (npc.target == gameObject.tag)
            {
                npc.withinRangeOfTarget = true;
            }    
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "NPC")
        {
            npc = collider.gameObject.GetComponent<NPCController>();
            npc.withinRangeOfTarget = false;
        }
    }

    void Start()
    {
        this.enabled = true;
    }
}
