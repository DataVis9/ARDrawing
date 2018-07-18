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
    public class SpeechCommandHandler : MonoBehaviour //, ISpeechHandler
    {

        public string[] keywords = new string[] { "red", "green", "blue" };
        public ConfidenceLevel confidence = ConfidenceLevel.Medium;

        protected PhraseRecognizer recognizer;
        protected string word = "right";

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
        public List<Vector3> GtransformLocations;
        public List<Vector3> BtransformLocations;
  

        public Quaternion rquat;

        private Vector3 RLastLoc;
        private Vector3 GLastLoc;
       // private Vector3 BLastLoc;



        void Start()
        {

            if (keywords != null)
            {
                recognizer = new KeywordRecognizer(keywords, confidence);
                recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
                recognizer.Start();

            }


            partBlue = BlueBrush.GetComponent<ParticleSystem>();
            partGreen = GreenBrush.GetComponent<ParticleSystem>();

            partBlue.Stop();
            partGreen.Stop();

            count = 0;
            RtransformLocations = new List<Vector3>();
            RLastLoc = RedBrush.transform.position;
            GLastLoc = GreenBrush.transform.position;
         //   BLastLoc = BlueBrush.transform.position;
           
            rquat = RedBrush.transform.rotation;
  
            
        }

        private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            word = args.text;
          //  results.text = "You said: <b>" + word + "</b>";
        }

        public void blueCollab()
        {
           

            count++;
            if (count % 2 != 0)
            {
                partBlue.Play();
            } else
            {
                partBlue.Stop();
            }
        }

        public void redCollab()
        {
            cntrR++;
            if(cntrR%2 != 0)
            {
                for (int i = 0; i < RtransformLocations.Count; i=i+2)
                  {
                      Instantiate(bubbles, 2 * RtransformLocations[i], rquat);

                   }
            } else
            {

            }
            
        }

        public void greenCollab()
        {
            cntrG++;
            if (cntrG % 2 != 0)
            {
                partGreen.Play();

            } else
            {
                partGreen.Stop();
            }
        }


        //turn on the renderer for "CollbObjects..."
        public void Update()
        {
            switch (word)
            {
                case "blue":
                    blueCollab();
                    break;
                case "green":
                    greenCollab();
                    break;
                case "red":
                    redCollab();
                    break;
            }
        }


        /* public void OnSpeechKeywordRecognized(SpeechEventData eventData)
         {
           /*  count++;
             if(count%2 != 0) //if count = 1, 3, 5...
             {

                     part.Play();
                     partG.Play();


                 sting = true;
             } else
             {
                 sting = false;
                 part.Stop();
                 partG.Stop();
             }

            // collabs.SetActive(true);

           //  DataLog vis = new DataLog();
           //  vis.collabDesired();



          //   var ins = new DataLog();
          //   ins.collabDesired();
            // throw new NotImplementedException();
         }*/

        private void OnApplicationQuit()
        {
            if (recognizer != null && recognizer.IsRunning)
            {
                recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
                recognizer.Stop();
            }
        }


    }
}

