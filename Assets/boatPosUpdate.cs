using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatPosUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 movement;
    private Vector3 originalPos;
    private Vector3 currentPos;
    private float hitZ;
    private float currentZ;
    private float randomValue;
    private float transparency;
    public bool is3Dboat;
    public Vector3 offset;
    void Start()
    {
        originalPos = transform.position;
        hitZ = transform.position.z;
        randomValue = Random.Range(0.0f, 1.0f);
        if (is3Dboat)
        {
            transparency = 0;
        }
        else
        {
            transparency = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update movement x using cosine function
        movement.x = originalPos.x + Mathf.Cos(Time.time + randomValue) * 2;
        movement.y = originalPos.y + Mathf.PerlinNoise(Time.time + randomValue, 0) * 2;
        movement.z = hitZ + Mathf.Sin(Time.time + randomValue) * 2;
        //lerp from current position to movement position
        transform.position = Vector3.Lerp(transform.position, movement, 0.01f);
        changeTransparency(is3Dboat);
        ApplyTransparency();
    }

    public void getPositionZ(float z)
    {
        hitZ = z;
    }

    private void changeTransparency(bool is3Dboat)
    {
        if (is3Dboat)
        {
            //map transparency from 0 to 1 using hitZ from 0 to 20
            transparency = limitMap(transform.position.z, 0, 10, 0, 1);
        }
        else
        {
            //map transparency from 1 to 0 using hitZ from 0 to 20
            transparency = limitMap(transform.position.z, 0, 10, 1, 0);
            Debug.Log(transparency);
        }
    }

    private void ApplyTransparency()
    {
        Color color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, transparency);
    }

    private float limitMap(float value, float start1, float stop1, float start2, float stop2)
    {
        value = Mathf.Clamp(value, start1, stop1);
        return (start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1)));
    }
}
