using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggContent
{
    [Serializable]
    public class Egg
    {
        public GameObject EggObject;
        public Rigidbody EggRigidbody;
        public int Hp;
        public int Def;
    }

}
