using UnityEngine;
using System.Diagnostics;

public class SpeakManager {

    #region singleton
    private static SpeakManager mInstance;

    public static SpeakManager Instance {

        get {

            if( mInstance == null ) {

                mInstance = new SpeakManager();
            }

            return mInstance;
        }
    }
    #endregion

    public delegate void SayEndDelegate();

    public event SayEndDelegate SayEndHandlers;    

    JSONObject speakJsonData;

    public SpeakManager () {

        TextAsset speakTexts = Resources.Load("SpeakTexts") as TextAsset;

        speakJsonData = new JSONObject(speakTexts.ToString());
    }

    public void Say ( string msgKey ) {

        string msg = speakJsonData.GetField(msgKey).str;

        Process process = new Process();

        process.StartInfo.FileName="say";
        process.StartInfo.Arguments = msg;

        process.EnableRaisingEvents = true;
        process.Exited += SayEnd;

        process.Start();
    }

    void SayEnd ( object sender, System.EventArgs e ) {

        SayEndHandlers();
    }
}
