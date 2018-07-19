using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
//using Vuforia;
using System.IO;

public class DataLog : MonoBehaviour {

    public GameObject RedBrush;
    public GameObject GreenBrush;
    public GameObject BlueBrush;
    public GameObject GradBrush;

    public List<Vector3> RtransformLocations; 
    public List<Vector3> GtransformLocations;
    public List<Vector3> BtransformLocations;
    public List<Vector3> GradtransformLocations;

    public List<string> colorOrder;

    private Vector3 RLastLoc;
    private Vector3 GLastLoc;
    private Vector3 BLastLoc;
    private Vector3 GradLastLoc;

    private int cntr;


    private Ray ray = new Ray();


    public string filePath;

    private string path;
    public TextWriter writer;
    protected string appendText;

  //public string[] lines2 = {"Started"};
  //   public List<string> lines;
  // public string mydocpath;

  //   public StreamWriter apd;
    

    // Use this for initialization
    void Start () {

        //NEW
        filePath = Application.persistentDataPath + "/LogData.txt";
        appendText = "Started!";

      //  lines.Add("start! ");

     //   mydocpath = Application.persistentDataPath;
     // apd = new StreamWriter(Path.Combine(mydocpath, "LogFile2.txt"));
     // Debug.Log("mark: " + apd);


        //if Data Log has no game object for brush, uncomment the lines below ...

        // RedBrush = GameObject.Find("RedBrush");
        // GreenBrush = GameObject.Find("GreenBrush");
        // BlueBrush = GameObject.Find("BlueBrush");
        // GradBrush = GameObject.Find("GradientBrush");

        cntr = 0;
    
        RtransformLocations = new List<Vector3>();
        RLastLoc = RedBrush.transform.position;
        GLastLoc = GreenBrush.transform.position;
        BLastLoc = BlueBrush.transform.position;
        GradLastLoc = GradBrush.transform.position;

        
        //WRITER
       // path = Path.Combine(Application.persistentDataPath, "LogFile.txt");
       // writer = File.CreateText(path);
        
	}

    // Update is called once per frame
    void Update()
    {
       
        ray.direction = Camera.main.transform.forward;
        ray.origin = Camera.main.transform.position;
       


        //if cntr is divisible by 59; aka, every 59 frames, do this hullaballoo underneath
        if (cntr % 59 == 0)
        {

           
           // writer.Write("Time: " + Time.time);
            //lines.Add("Time: " + Time.time);
         //   writer.Close();


            //    Debug.Log("GREAT SCOTT! " + ray.direction);



            //write data about the Red brush's location to file
            if (RLastLoc != RedBrush.transform.position)
            {
                
            //    writer.Write(" - Red Brush Position: " + RedBrush.transform.position);
                appendText = appendText + "Red Brush Position: " + RedBrush.transform.position;

                RtransformLocations.Add(RedBrush.transform.position);
                RLastLoc = RedBrush.transform.position;
           //     writer.Close();
            

            }

            //write data about the Green brush's location to file
            if (GLastLoc != GreenBrush.transform.position)
            {
                Debug.Log(" - Green Brush Position: " + GreenBrush.transform.position);
            //    writer.Write(" - Green Brush Position: " + GreenBrush.transform.position);
                GtransformLocations.Add(GreenBrush.transform.position);
                GLastLoc = GreenBrush.transform.position;
          //      writer.Close();


            }

            //write data about the Blue brush's location to file
            if (BLastLoc != BlueBrush.transform.position)
            {
                Debug.Log(" - Blue Brush Position: " + BlueBrush.transform.position);
           //     writer.Write("Blue Brush Position: " + BlueBrush.transform.position);
                BtransformLocations.Add(BlueBrush.transform.position);
                BLastLoc = BlueBrush.transform.position;
               // writer.Close();


            }

            //write data about the Gradient brush's location to file
            if (GradLastLoc != GradBrush.transform.position)
            {
                Debug.Log(" - Gradient Brush Position: " + GradBrush.transform.position);
           //     writer.WriteLine("Gradient Brush Position: " + GradBrush.transform.position);
                GradtransformLocations.Add(GradBrush.transform.position);
                GradLastLoc = GradBrush.transform.position;
               
                // Debug.Log("Total gradient position points collected: " + GradtransformLocations.Count);

               // colorOrder.Add("Gradient at " + Time.time);

            }
        }
        cntr++;  
    }

    public void redVis(string stahp)
    {
        Debug.Log(stahp);
   //     writer.WriteLine(stahp);
    }

    public void greenVis(string stahp)
    {
        Debug.Log(stahp);
    //    writer.WriteLine(stahp);
    }

    public void blueVis(string stahp)
    {
        Debug.Log(stahp);
   //     writer.WriteLine(stahp);
    }


    public void collabDesired()
    {
        //this method always causes an error in unity; best idea would be to just manually track whether or not the test used collaboration or not
        Debug.Log("test");
     //   writer.WriteLine("Collaboration desired");
       
    }

    private void OnApplicationQuit()
    {
        /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "LogData.txt")))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
            foreach (string line in lines )
                Debug.Log(line);

        }
        File.AppendAllLines(Path.Combine(mydocpath, "WriteFile.txt"), lines);*/
        Debug.Log(appendText);
        File.AppendAllText(filePath, appendText);

       // writer.Close();
    }


}

