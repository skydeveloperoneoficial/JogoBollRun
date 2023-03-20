using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public float speedMove;

	private GameController gameController;
	
	public EnemyController enemyController;
	// Use this for initialization
	void Start () {
	gameController = FindObjectOfType(typeof(GameController))as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.GetCurrentState() == stateMachine.PLAY){
			
			//Enemy Action
			transform.Translate(Vector3.forward*speedMove*enemyController.difficultyFactor);
			transform.LookAt(gameController.player.transform.position);
			
			if(transform.position.y < -5){
				Destroy(gameObject);
				enemyController.DecreaseEnemy();
			}
			
			
		}
	}
}
