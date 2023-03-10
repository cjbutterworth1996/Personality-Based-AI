using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public int thirst;
    public int hunger;
    public int bladder;
    public int energy;
    public int boredom;

    void Start ()
    {
        this.enabled = true;
    }

    void Drink()
    {
        target = sink.transform;
    }
}
