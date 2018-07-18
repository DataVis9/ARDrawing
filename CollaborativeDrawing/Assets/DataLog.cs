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
 
    private string path;
    private TextWriter writer;

    

    // Use this for initialization
    void Start () {



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


        

        path = Path.Combine(Application.persistentDataPath, "LogFile.txt");
        writer = File.CreateText(path);
        
	}

    // Update is called once per frame
    void Update()
    {

        ray.direction = Camera.main.transform.forward;
        ray.origin = Camera.main.transform.position;
        /*  RaycastHit hitInfo;
          if (Physics.Raycast(
                  Camera.main.transform.position,
                  Camera.main.transform.forward,
                  out hitInfo,
                  20.0f,
                  Physics.DefaultRaycastLayers))
          {
              // If the Raycast has succeeded and hit a hologram
              // hitInfo's point represents the position being gazed at
              //Debug.Log("GREAT SCOTT " + hitInfo.transform.position);
              // hitInfo's collider GameObject represents the hologram being gazed at
          }*/





        //if cntr is divisible by 59; aka, every 59 frames, do this hullaballoo underneath
        if (cntr % 59 == 0)
        {

           
            writer.Write("Time: " + Time.time);

         

        //    Debug.Log("GREAT SCOTT! " + ray.direction);



            //write data about the Red brush's location to file
            if (RLastLoc != RedBrush.transform.position)
            {
                Debug.Log(" - Red Brush Position: " + RedBrush.transform.position);
                writer.Write(" - Red Brush Position: " + RedBrush.transform.position);
                RtransformLocations.Add(RedBrush.transform.position);
                RLastLoc = RedBrush.transform.position;
            
                //  Debug.Log("Total red position points collected: " + RtransformLocations.Count);
                //  RTime = RTime + (Time.deltaTime /* - RTime*/);
                // Debug.Log("Time: " + RTime);

                // colorOrder.Add("Red at " + Time.time);


            }

            //write data about the Green brush's location to file
            if (GLastLoc != GreenBrush.transform.position)
            {
                Debug.Log(" - Green Brush Position: " + GreenBrush.transform.position);
                writer.Write(" - Green Brush Position: " + GreenBrush.transform.position);
                GtransformLocations.Add(GreenBrush.transform.position);
                GLastLoc = GreenBrush.transform.position;
               
                //   Debug.Log("Total green position points collected: " + GtransformLocations.Count);
                // GTime = GTime + (Time.deltaTime /*- GTime*/);
                //  Debug.Log("Time: " + GTime);
             //   colorOrder.Add("Green at " + Time.time);
                // Instantiate

            }

            //write data about the Blue brush's location to file
            if (BLastLoc != BlueBrush.transform.position)
            {
                Debug.Log(" - Blue Brush Position: " + BlueBrush.transform.position);
                writer.Write("Blue Brush Position: " + BlueBrush.transform.position);
                BtransformLocations.Add(BlueBrush.transform.position);
                BLastLoc = BlueBrush.transform.position;
               
                //  Debug.Log("Total blue position points collected: " + BtransformLocations.Count);
                // BTime = BTime + Time.deltaTime;
               // colorOrder.Add("Blue at " + Time.time);

            }

            //write data about the Gradient brush's location to file
            if (GradLastLoc != GradBrush.transform.position)
            {
                Debug.Log(" - Gradient Brush Position: " + GradBrush.transform.position);
                writer.WriteLine("Gradient Brush Position: " + GradBrush.transform.position);
                GradtransformLocations.Add(GradBrush.transform.position);
                GradLastLoc = GradBrush.transform.position;
               
                // Debug.Log("Total gradient position points collected: " + GradtransformLocations.Count);

               // colorOrder.Add("Gradient at " + Time.time);

            }
        }
        cntr++;  
    }

/*
    public void OnApplicationQuit()
    {
        //red
        Debug.Log("Red Brush's Positions: ");
        for(int i = 0; i<RtransformLocations.Count; i++)
        {
            Debug.Log(RtransformLocations.ElementAt(i));
        }
        writer.WriteLine("Red Brush's Positions: ");
        for (int i = 0; i < RtransformLocations.Count; i++)
        {
            writer.WriteLine(RtransformLocations.ElementAt(i));
        }

        //Green
        Debug.Log("Green Brush's Positions: ");
        for (int i = 0; i < GtransformLocations.Count; i++)
        {
            Debug.Log(GtransformLocations.ElementAt(i));
        }
        writer.WriteLine("Green Brush's Positions: ");
        for (int i = 0; i < GtransformLocations.Count; i++)
        {
            writer.WriteLine(GtransformLocations.ElementAt(i));
        }

        //Blue
        Debug.Log("Blue Brush's Positions: ");
        for (int i = 0; i < BtransformLocations.Count; i++)
        {
            Debug.Log(BtransformLocations.ElementAt(i));
        }
        writer.WriteLine("Blue Brush's Positions: ");
        for (int i = 0; i < BtransformLocations.Count; i++)
        {
            writer.WriteLine(BtransformLocations.ElementAt(i));
        }

        //Gradient
        Debug.Log("Gradient Brush's Positions: ");
        for (int i = 0; i < GradtransformLocations.Count; i++)
        {
            Debug.Log(GradtransformLocations.ElementAt(i));
        }
        writer.WriteLine("Gradient Brush's Positions: ");
        for (int i = 0; i < GradtransformLocations.Count; i++)
        {
            writer.WriteLine(GradtransformLocations.ElementAt(i));
        }

        //Color order and timing
        Debug.Log("color order: ");
        for (int i = 0; i < colorOrder.Count; i++)
        {
            Debug.Log(colorOrder.ElementAt(i));
        }
        writer.WriteLine("color order: ");
        for (int i = 0; i < colorOrder.Count; i++)
        {
            writer.WriteLine(colorOrder.ElementAt(i));
        }
    }
    */

    public void collabDesired()
    {
        //this method always causes an error in unity; best idea would be to just manually track whether or not the test used collaboration or not
        Debug.Log("test");
        writer.WriteLine("Collaboration desired");
    }


}

