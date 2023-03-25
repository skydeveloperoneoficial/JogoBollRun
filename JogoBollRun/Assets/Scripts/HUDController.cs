using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {
	
	public TextMesh score;
	public PlayerBehaviour player;
	public Transform barPee;
	
	private Vector3 newSize;
	private Vector3 sizeBarPee;

	// Use this for initialization
	void Start () {
		sizeBarPee = barPee.transform.localScale;
		newSize = sizeBarPee;
	}
	
	// Update is called once per frame
	void Update () {
		
		newSize.x = sizeBarPee.x * player.getCurrentPee() / player.totalPee;
		
		barPee.transform.localScale = newSize;
		

	
	}
	
	public void AddScore(int newScore){
		score.text = "Score: "+newScore;
		
	}
}
