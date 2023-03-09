using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public int thirst = 100;
    public int hunger = 100;
    public int bladder = 100;
    public int energy = 100;
    public int boredom = 100;

    void Start ()
    {
        this.enabled = true;
    }
}
