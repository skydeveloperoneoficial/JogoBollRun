using UnityEngine;
using System.Collections;

public enum stateMachine{
	START,
	RELOAD,
	PAUSED,
	PLAY,
	WIN,
	LOSE,
	NULL
}

public class GameController : MonoBehaviour {
	
	private stateMachine currentState = stateMachine.START;
	private stateMachine lastState = stateMachine.NULL;
	
	
	private int score;
	private float currentTimeToScore = 0;
	private float currentTimeToRespawn = 0;
	
	public PlayerBehaviour player;
	public HUDController HUD;
	public CheckPointController checkPoint;
	public EnemyController enemyController;
	public int basePoints = 1;
	public int pointsCheckPoint = 1;
	public float timeToScore = 3;
	public float timeToRespawn = 2;
	private Transform currentCheckPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameStateMachine();
	}
	
	public void SwitchState(stateMachine nextState){
		lastState = currentState;
		currentState = nextState;	
	}
	
	public stateMachine GetCurrentState(){
		return currentState;
	}
	
	void GameStateMachine(){
		
		switch(currentState){
		case stateMachine.START:
		{
			score = 0;
			HUD.AddScore(score);
			SwitchState(stateMachine.PLAY);
			
			currentCheckPoint = checkPoint.SpawnCheckPoint();

		}
		break;
		case stateMachine.RELOAD:
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
		break;
		case stateMachine.PAUSED:
		{
			//input 
			BasicInputs();
		}
		break;
		case stateMachine.PLAY:
		{
			//Player
			player.Move();
			player.IncreaseXixi();
			
			//input 
			BasicInputs();
			
			//Score
			currentTimeToScore += Time.deltaTime;
			if(currentTimeToScore > timeToScore){
				currentTimeToScore = 0;
				score++;
				HUD.AddScore(score*basePoints);
			}
			
			
		}
		break;
		case stateMachine.WIN:
		{		
			
			currentTimeToRespawn += Time.deltaTime;
			
			if(currentTimeToRespawn >= timeToRespawn){
				currentTimeToRespawn = 0;
				SwitchState(stateMachine.PLAY);
				
				//input 
				BasicInputs();
				
				checkPoint.SpawnInNewPosition(currentCheckPoint);
				
				
				score += pointsCheckPoint;
				HUD.AddScore(score*basePoints);

	
				//player.ResetPosition();
				
				enemyController.AddDifficulty();
			}
			
			
		}
		break;
		case stateMachine.LOSE:
		{
			ApplicationController.AddToRanking(score*basePoints);
			Application.LoadLevel("Ranking");
			
		}
		break;
		}
		
		
	}
	
	
	
	void BasicInputs(){
		if(Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PLAY){
			SwitchState(stateMachine.PAUSED);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PAUSED){
			SwitchState(stateMachine.PLAY);
		}
		else if(Input.GetKeyDown(KeyCode.R)){
			SwitchState(stateMachine.RELOAD);
		}
	}
}
