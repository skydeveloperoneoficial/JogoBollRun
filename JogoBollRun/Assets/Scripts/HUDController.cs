using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {
	
	public  TextMesh score;
	public PlayerBehaviour player;
	public Transform barXixi;
	
	private Vector3 newSize;
	private Vector3 sizeBarXixi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		

	
	}
	
	public void AddScore(int newScore){
		score.text = "Score: "+newScore;
		
	}
}
