using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class buttongray : MonoBehaviour, ITrackableEventHandler
{
    GameObject BSound, BVideo;

    private TrackableBehaviour mTrackableBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        BSound = GameObject.Find("buttongray");
        BVideo = GameObject.Find("buttonmesin");

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        BSound.SetActive(true);
        BVideo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "buttongray")
                {
                    BSound.SetActive(false);
                    BVideo.SetActive(true);
                    BSound.GetComponent<AudioSource>().Play();
                }

                if (hit.collider.tag == "buttonmesin")
                {
                    BSound.SetActive(true);
                    BVideo.SetActive(false);
                    BVideo.GetComponent<AudioSource>().Stop();
                }
            }
        }
    }
}
