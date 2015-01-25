﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PolygonRenderer))]
public class ObjectStateManager : MonoBehaviour
{
	public bool initialized;

	public SimpleStateMachine stateMachine;
	SimpleState circleState, clockState, squareState, playState, disconnectState, finishedState;

	PolygonRenderer poly;

	public List<GameObject> objects;

	void Start()
	{
		Init();
	}

	public void Init () 
	{
		poly = gameObject.GetComponent<PolygonRenderer> ();

		circleState = new SimpleState(CircleEnter, CircleUpdate, CircleExit, "CIRCLE");
		clockState = new SimpleState(ClockEnter, ClockUpdate, ClockExit, "CLOCK");
		squareState = new SimpleState(SquareEnter, SquareUpdate, SquareExit, "SQUARE");

		/*
		playState = new SimpleState(PlayEnter, PlayUpdate, PlayExit, "PLAY");
		disconnectState = new SimpleState(DisconnectEnter, DisconnectUpdate, DisconnectExit, "DISCONNECT");
		finishedState = new SimpleState(null, null, null, "FINISHED");
		*/

		Circle();
	}
	void Update () 
	{
		Execute();
	}

	public void Circle () 
	{
		stateMachine.SwitchStates(circleState);
	}

	public void Execute () 
	{
		stateMachine.Execute();
	}

	#region circle
	void CircleEnter() 
	{
		//poly.CreateNGon (20, 1);
	}

	void CircleUpdate() 
	{
		if (Vector3.Distance(objects[0].transform.position, objects[1].transform.position) < 1) {
			stateMachine.SwitchStates(clockState);
				}
	}

	void CircleExit() {}
	#endregion

	#region clock
	void ClockEnter() {
		Debug.Log ("Clock");
	}

	void ClockUpdate() {}

	void ClockExit() {}
	#endregion

	#region square
	void SquareEnter() {
		//BlendHandler.Instance.Blend (this.gameObject, Resources.Load ("test") as GameObject);
		//BlendHandler.Instance.Blend (this.gameObject, to_shape, 3.0f);

		//poly.CreateNGon (4,1);

	}

	void SquareUpdate() 
	{

	}

	void SquareExit() 
	{

	}
	#endregion

	#region PLAY
	void PlayEnter()
	{
		
	}

	void PlayUpdate() 
	{
		
	}

	void PlayExit() {}
	#endregion

	#region DISCONNECT
	void DisconnectEnter() {}

	void DisconnectUpdate() {}

	void DisconnectExit() 
	{
		stateMachine.SwitchStates(clockState);
	}
	#endregion
}
