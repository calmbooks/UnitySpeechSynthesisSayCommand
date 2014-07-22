using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    SpeakManager speakManager;

	void Start () {

        speakManager = new SpeakManager();	

        speakManager.Say("HELLO_WORLD");

        speakManager.SayEndHandlers += SayEnd;
	}

    void SayEnd () {

        Debug.Log("SayEnd");
    }
}
