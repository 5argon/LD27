﻿using UnityEngine;
using System.Collections; 

public class GameOverChecker : MonoBehaviour {
	public MeshRenderer cat;
	
	public GameObject triggerTouchTheGround;
    public Transform gameLosePrefab;
    public Transform gameWinPrefab;
	
	private TriggerTouchTheGround refTriggerTouchTheGround;
	private bool isGameOverStateReached = false;

    void Start() {
		// get the reference game objects
		refTriggerTouchTheGround = (TriggerTouchTheGround)triggerTouchTheGround.GetComponent("TriggerTouchTheGround");
		isGameOverStateReached = false;
	}

	void Update () {
		if(!isGameOverStateReached)
		{
			// GAMEOVER: less than 10 secs, and not touch the ground yet
			if(CountDownTimer.instance.GetTimeRemaining() < 0.0f && !refTriggerTouchTheGround.GetIsCatTouchedTheGround())
			{
				Debug.Log ("Game Over!!");
				cat.material.color = Color.yellow;
				
				// Send message for GAMEOVER
	            //gameObject.BroadcastMessage("onGameOver", SendMessageOptions.RequireReceiver);
	            Instantiate(gameLosePrefab);
				
				isGameOverStateReached = true;
			}
			else if(CountDownTimer.instance.GetTimeRemaining() > 0.0f && refTriggerTouchTheGround.GetIsCatTouchedTheGround())
			{
				Debug.Log ("Win!!");
				cat.material.color = Color.green;
				
				// Send message for WINNING 
	            //gameObject.BroadcastMessage("onWin", SendMessageOptions.RequireReceiver);
	            Instantiate(gameWinPrefab);
				
				isGameOverStateReached = true;
			}
		}
	}
}
