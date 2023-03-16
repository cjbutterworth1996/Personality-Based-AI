using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private NPCController npc;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPCController>();

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
            npc.withinRangeOfTarget = false;
        }
    }
}
