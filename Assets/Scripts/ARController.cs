using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    public GameObject trackingObj;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        ImageTracking.OnTrackedImageChanged += TrackedImageChanged;
    }

    private void OnDisable()
    {
        ImageTracking.OnTrackedImageChanged -= TrackedImageChanged;
    }

    public void TrackedImageChanged(ARTrackedImage trackedImage)
    {
        switch (trackedImage.trackingState)
        {
            case TrackingState.Limited:
                trackingObj.SetActive(false);
                break;
            case TrackingState.Tracking:
                trackingObj.SetActive(true);
                trackingObj.transform.position = trackedImage.transform.position;
                trackingObj.transform.localEulerAngles = trackedImage.transform.localEulerAngles;
                break;
        }
    }
}
