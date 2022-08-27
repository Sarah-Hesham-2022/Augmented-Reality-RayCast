using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneFinder : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _rayCastManager;
    [SerializeField] private ARSessionOrigin _origin;
    [SerializeField] private Transform indicator;
    [SerializeField] private GameObject placePrefab;
    private bool canSet;
    // Start is called before the first frame update
    void Start()
    {
        canSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        //var ray = _origin.camera.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        var ray = _origin.camera.ViewportPointToRay(new Vector2(0.5f,0.5f));
        var hits=new List<ARRaycastHit>();
        if(_rayCastManager.Raycast(ray,hits,UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var pose = hits[0].pose;  
            indicator.position = pose.position;
            indicator.rotation = pose.rotation;
            canSet = true;
        }
        else
        {
            canSet=false;
        }
        if(Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if(canSet && touch.phase==TouchPhase.Began)
            {
                Instantiate(placePrefab,indicator.position,indicator.rotation); 
            }
        }
}
}
