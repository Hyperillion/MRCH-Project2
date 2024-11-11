using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Camera mainCamera;  // Assign your camera here
    public float maxDistance = 100f;  // Maximum raycast distance
    private GameObject boat1;

    void Start(){
        boat1 = GameObject.Find("boat1");
    }
    void Update()
    {
        // Raycast from the camera's position in the forward direction
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            // If an object is hit, get its position and object
            Vector3 hitPosition = hit.point;
            GameObject hitObject = hit.collider.gameObject;
            //if being hit
            if (hitObject.name == "TriggerRaycast")
            {
                Vector3 newPos = new Vector3(boat1.transform.position.x, boat1.transform.position.y, hitPosition.z);
                // boat1.transform.position = newPos;
                //lerp from current position to new position
                boat1.transform.position = Vector3.Lerp(boat1.transform.position, newPos, 0.01f);
            }
        }
        else
        {
            Debug.Log("Camera is not looking at any object within the specified distance.");
        }
    }
}
