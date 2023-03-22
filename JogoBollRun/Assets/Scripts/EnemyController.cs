using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		
			if(currentEnemys < totalEnemysInGame){
		
			if(currentTime > timeToRespawn && gameController.GetCurrentState() == stateMachine.PLAY){
				CreateEnemy();
				currentTime = 0;

			}
			else{
				currentTime += Time.deltaTime;
			}
			
		}
	}
	
	void CreateEnemy(){
		
	
		GameObject tempEnemy = Instantiate(enemy.gameObject) as GameObject;
		
		tempEnemy.transform.parent = transform;
		
		Vector3 newPosition = gameController.player.transform.position;
		
		newPosition.x = newPosition.x+(Random.Range(radiusMin, radiusMax));
		newPosition.z = newPosition.z+(Random.Range(radiusMin, radiusMax));
		
		tempEnemy.transform.position = newPosition;
		
		tempEnemy.GetComponent<EnemyBehaviour>().enemyController = this;
		
		currentEnemys++;


		
	}	
	public void AddDifficulty(){
		difficultyFactor += difficultyAdd;
	}
	
	
	
=======
	
	}
>>>>>>> parent of bcce002 (Maquina de estados)
}
