using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton() {
        Invoke("StageSelect", .5f);

    }

    void StageSelect() {
        Application.LoadLevel("Stage select");

    }
}
