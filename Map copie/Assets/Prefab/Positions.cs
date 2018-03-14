using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.Experimental.UIElements.Slider;

public class Postions

{
    private Bloc bloc;

    public enum Direction
    {
        North,
        South,
        East, 
        West
    }
    private Direction direction;

    public Postions(Bloc bloc, Direction direction)
    {
        this.bloc = bloc;
        this.direction = direction;
    }
    
}
