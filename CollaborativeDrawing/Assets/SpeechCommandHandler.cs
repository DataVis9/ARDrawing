using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkitExtensions.Messaging;

using UnityEngine.UI;
using UnityEngine.Windows.Speech;

using System;
//using HoloPixelArt.Messages;

namespace CollaborativeDrawing
{
    public class SpeechCommandHandler : MonoBehaviour , ISpeechHandler
    {

        DataLog dat;

        ParticleSystem partBlue;
        ParticleSystem partGreen;

        public GameObject bubbles;
        int count;
        int cntrR;
        int cntrG;
       

        public GameObject RedBrush; 
        public GameObject GreenBrush;
        public GameObject BlueBrush;
     

        public List<Vector3> RtransformLocations;
      //  public List<Vector3> GtransformLocations;
     //   public List<Vector3> BtransformLocations;
  

        public Quaternion rquat;

        private Vector3 RLastLoc;
       // private Vector3 GLastLoc;
       // private Vector3 BLastLoc;



        void Start()
        {
         
            dat = FindObjectOfType<DataLog>();

            partBlue = BlueBrush.GetComponent<ParticleSystem>();
            partGreen = GreenBrush.GetComponent<ParticleSystem>();

            partBlue.Stop();
            partGreen.Stop();

            count = 0;
            RtransformLocations = new List<Vector3>();
            RLastLoc = RedBrush.transform.position;
         //   GLastLoc = GreenBrush.transform.position;
         //   BLastLoc = BlueBrush.transform.position;
           
            rquat = RedBrush.transform.rotation;
  
            
        }

       public void Update()
        {
            if (RLastLoc != RedBrush.transform.position)
            {
               
                RtransformLocations.Add(RedBrush.transform.position);
                RLastLoc = RedBrush.transform.position;

              


            }
        }

        public void blueCollab()
        {
        

            count++;
            if (count % 2 != 0)
            {
                partBlue.Play();
            
                dat.blueVis("Collaborated with blue brush");
                 
            } else
            {
                partBlue.Stop();
        
                dat.blueVis("Stopped collaborating with blue brush");
                 
            }
        }

        public void redCollab()
        {
            cntrR++;
            if(cntrR%2 != 0) //for cntrR = 1, 3, 5...
            {
                for (int i = 0; i < RtransformLocations.Count; i++)
                {
                    Instantiate(bubbles, 2 * RtransformLocations[i], rquat);
                }
                dat.redVis("Collaborated with red brush");
            } else
            {
                dat.redVis("stopped collab with red brush");
            }
        }

        public void greenCollab()
        {
            cntrG++;
            if (cntrG % 2 != 0)
            {
                partGreen.Play();
                dat.greenVis("Collaborated with green brush");
            } else
            {
                partGreen.Stop();
                dat.greenVis("stopped collab with green brush");
            }
        }


       
       


         public void OnSpeechKeywordRecognized(SpeechEventData eventData)
         {

            switch (eventData.RecognizedText)
            {
                case "blue":                                                                    //wow I love Coldplay. 
                    blueCollab();
                    Debug.Log("blue");

                    break;
                case "green":                                                                   //shrek
                    greenCollab();
                    Debug.Log("green");
                    break;
                case "red":                                                                     //Vision
                    redCollab();
                    Debug.Log("red");
                    break;
            }



            
        }

     


    }
}

