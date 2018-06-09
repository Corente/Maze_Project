using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bloc
{
    public GameObject AMB;
    public string type;
    public int rotate;
    public int xpos, zpos;
    public GameObject obj;
    public GameObject particule;
    
    public Bloc ()
    {
        type = null;
        rotate = Random.Range(1,4);
        AMB = null;       
        obj = null;
        particule = null;
    }

    
}
