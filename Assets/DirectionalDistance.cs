using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalDistance : MonoBehaviour
{
    private GameObject SwimmingPoolTrigger;
    private GameObject ARSession;

    // Start is called before the first frame update
    void Start()
    {
        SwimmingPoolTrigger = GameObject.Find("SwimmingPoolTrigger");
        ARSession = GameObject.Find("AR Session");

        if (SwimmingPoolTrigger != null && ARSession != null)
        {
            Debug.Log("Objects found");
        }
        else
        {
            Debug.Log("One or both objects not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SwimmingPoolTrigger != null && ARSession != null)
        {
            float distance = Vector3.Distance(SwimmingPoolTrigger.transform.position, ARSession.transform.position);
            Debug.Log("Distance: " + distance);
        }
    }
}
