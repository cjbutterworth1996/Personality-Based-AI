using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public class Needs
    {
        public float thirst = 100f;
        public float hunger = 100f;
        public float bladder = 100f;
        public float energy = 100f;
    }

    public class Happiness
    {
        public float boredom = 100f;
    }
}
