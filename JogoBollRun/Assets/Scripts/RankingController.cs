using UnityEngine;
using System.Collections;

public class RankingController : MonoBehaviour {
	
	public TextMesh scoreDisplay;
	
	// Use this for initialization
	void Start () {
		
		scoreDisplay.text = "";
		
		
	}
	
	// Update is called once per frame
	void Update () {
		BasicInputs();
	
	}
	
	void BasicInputs(){
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel("GamePlay");
		}
	}
}
