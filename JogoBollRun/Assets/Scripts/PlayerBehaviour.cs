 using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	public float totalPee = 10;
	
	public float PeeToIncrease = 1;
	public float timeToPee = 4;
	
	public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
	
	public GameController gameController;
	
	private Vector3 startPosition;
	private float currentTimeToPee = 0;
	private float currentPee = 0;
	
	
	// Use this for initialization
	void Start () {		
		startPosition = transform.position;

	}
	
	// Update is called once per frame
	public void Move () {
		CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
		
		if(transform.position.y < -5){
			gameController.SwitchState(stateMachine.LOSE);
		}
		
	
	}
	
	public float getCurrentPee(){
		return currentPee;
	}
	
	public void IncreasePee(){
		currentTimeToPee += Time.deltaTime;
		
		if(currentTimeToPee > timeToPee){
			currentTimeToPee = 0;
			currentPee += PeeToIncrease;
		}
		
		if(currentPee > totalPee){
			gameController.SwitchState(stateMachine.LOSE);
		}
		
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
    	if(hit.gameObject.tag == "Enemy"){
	   		gameController.SwitchState(stateMachine.LOSE);
		}
		if(hit.gameObject.tag == "CheckPoint"){
			currentPee = 0;
			gameController.SwitchState(stateMachine.WIN);
		}

		
		
    }
	
	public void ResetPosition(){
		transform.position = startPosition;
	}
	
	

   

}
