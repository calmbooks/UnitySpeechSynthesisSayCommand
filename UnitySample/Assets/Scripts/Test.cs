using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    SpeakManager speakManager;

	void Start () {

        speakManager = new SpeakManager();	

        speakManager.Say("こんにちは 世界");

        speakManager.SayEndHandlers += SayEnd;
	}

    void SayEnd () {

        Debug.Log("SayEnd");
    }
}
