using UnityEngine;
using System.Collections;

public class InputGameController : MonoBehaviour {
	
	private stateMachine currentState = stateMachine.START;
	private stateMachine lastState = stateMachine.NULL;
	
	public GameController gc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	 public void BasicInputs(){
		if(Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PLAY){
		 gc.SwitchState(stateMachine.PAUSED);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && currentState == stateMachine.PAUSED){
			gc.SwitchState(stateMachine.PLAY);
		}
		else if(Input.GetKeyDown(KeyCode.R)){
			gc.SwitchState(stateMachine.RELOAD);
		}
	}
}
