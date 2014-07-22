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

    public void Say ( string msg ) {

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
