using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImageDisapper : MonoBehaviour
{
    private Vector3 position;
    private float transparency = 1;
    // Start is called before the first frame update
    void Start()
    {
        position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the camera is 0.5 meter away from the 'position' value, the transparency lerp to be 0
        if (Vector3.Distance(position, Camera.main.transform.position) > 0.5f)
        {
            transparency = Mathf.Lerp(transparency, 0, 0.1f);
        }
        else
        {
            transparency = Mathf.Lerp(transparency, 1, 0.1f);
        }
        ApplyTransparency();
    }

    private void ApplyTransparency()
    {
        GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, transparency);

    }
}
