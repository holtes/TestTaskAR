using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;


public class ImageTracking : MonoBehaviour
{
    public static event Action<ARTrackedImage> OnTrackedImageChanged;

    private ARTrackedImageManager m_TrackedImageManager;

    public static ImageTracking instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SceneManager.LoadScene("1-3D", LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        if (m_TrackedImageManager == null)
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        }
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        for (int i = 0; i < eventArgs.updated.Count; i++)
        {
            OnTrackedImageChanged?.Invoke(eventArgs.updated[i]);
        }
    }
}
