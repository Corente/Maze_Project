﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Bloc
{
    public bool west, east, south, north, artefact;
    public bool type1, type2, type3;
    private int type;
    public int rotate;
    public int xpos, zpos;
    public Rigidbody Rb;
    private Postions pos;
    
    
    public Bloc ()
    {
        west = false;
        east = false;
        south = false;
        north = false;
        type = Random.Range(1,4);
        rotate = Random.Range(1,4);
        artefact = Random.Range(0,1) == 1;
        type1 = false;
        type2 = false;
        type3 = false;
        Rb = new Rigidbody();
        
        Typed();
    }

    private void Typed()
    {
        if (type == 1)
        {
            type1 = true;
        }
        else if (type == 2)
        {
            type2 = true;
        }
        else if (type == 3)
        {
            type3 = true;
        }
    }
    
    
}
