using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WIN : MonoBehaviour
{

	protected bool win;
	protected bool end;

	protected bool begin;
	protected int X_max;
	protected int Y_max;
	protected float timer;

	public bool QTE;
	
	public bool Win
	{
		get { return win; }
		set { win = value; }
	}
	
	public bool End
	{
		get { return end; }
		set { end = value; }
	}
	
	public bool Begin
	{
		get { return begin; }
		set { begin = value; }
	}

	public float Timer
	{
		get { return timer; }
		set { timer = value; }
	}
}
