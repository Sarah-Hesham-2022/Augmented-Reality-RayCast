using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Scene2 : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _rayCastManager;
    [SerializeField] private ARSessionOrigin _origin;
    [SerializeField] private Transform indicator;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int sizeArray;
    private int index;
    private int checkNotRepeat;

    private GameObject obj;

    private bool canSet;

    // Start is called before the first frame update
    void Start()
    {
        canSet = false;

        checkNotRepeat = -1;

        index = Random.Range(0, sizeArray);

        obj = objects[0];

    }
    // Update is called once per frame
    void Update()
    {
        //var ray = _origin.camera.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));

        var ray = _origin.camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        var hits = new List<ARRaycastHit>();

        if (_rayCastManager.Raycast(ray, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var pose = hits[0].pose;
            indicator.position = pose.position;
            indicator.rotation = pose.rotation;
            canSet = true;
        }
        else
        {
            canSet = false;
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (canSet && touch.phase == TouchPhase.Began)
            {
                if (checkNotRepeat != index)
                {
                    obj.GetComponent<AudioSource>().Stop();
                    obj.GetComponent<Animator>().enabled = false;

                    obj = Instantiate(objects[index], indicator.position, indicator.rotation);
                    obj.GetComponent<AudioSource>().Play();
                    obj.GetComponent<Animator>().enabled = true;

                    checkNotRepeat = index;
                    index = Random.Range(0, sizeArray);
                }
                else
                {
                    while (index == checkNotRepeat)
                    {
                        index = Random.Range(0, sizeArray);
                    }
                    obj.GetComponent<AudioSource>().Stop();
                    obj.GetComponent<Animator>().enabled = false;

                    obj = Instantiate(objects[index], indicator.position, indicator.rotation);
                    obj.GetComponent<AudioSource>().Play();
                    obj.GetComponent<Animator>().enabled = true;

                    checkNotRepeat = index;
                    index = Random.Range(0, sizeArray);
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                obj.transform.position = hits[0].pose.position;
                obj.transform.rotation = hits[0].pose.rotation;
            }
        }
    }
}