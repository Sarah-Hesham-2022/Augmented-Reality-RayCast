using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Scene3 : MonoBehaviour
{
    [SerializeField] private ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] private GameObject ballPrefab;
    Camera arCam;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        
    }

    private void ballPrefabInst(Vector3 pos)
    {
        ball = Instantiate(ballPrefab,pos,Quaternion.identity);
        ball.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

       RaycastHit hit;
       Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && ball == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Ball")
                    {
                        ball = hit.collider.gameObject;
                    }
                    else
                    {
                        ballPrefabInst(m_Hits[0].pose.position);
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && ball != null)
            {
                ball.transform.position = m_Hits[0].pose.position;   
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ball = null;
            }
        }
    }
}
