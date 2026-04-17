using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        // MOBILE TOUCH
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject(Input.GetTouch(0).position);
        }

        // MOUSE CLICK (for editor)
        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject(Input.mousePosition);
        }
    }

    void PlaceObject(Vector2 screenPosition)
    {
        
        
            if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                Vector3 spawnPosition = hitPose.position + new Vector3(0, 0.3f, 0);

                Instantiate(objectToPlace, spawnPosition, hitPose.rotation);
            }
        
    }
}