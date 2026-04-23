using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageDetector : MonoBehaviour
{
    private ARTrackedImageManager _trackedImageManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
       _trackedImageManager.trackablesChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        _trackedImageManager.trackablesChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added)
        {
            string imageName = image.referenceImage.name;
            Vector3 spawnPosition = image.transform.position;
            Debug.Log("Image Added: "+imageName);
            switch (imageName)
            {
                case "one":
                    GameObject cube =  GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.SetParent(image.transform, false);
                    cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    
                    break;
                case "Rafflesia":
                    GameObject sphere =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.SetParent(image.transform,false);
                    sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    
                    break;
                default:
                    Debug.Log("Prefab Not Found");
                    break;
                
            }
            
            //continue
            
            
        }

        foreach (ARTrackedImage image in eventArgs.updated)
        {
            
        }

        foreach (var image in eventArgs.removed)
        {
            Debug.Log("Image Removed");
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
    

}
