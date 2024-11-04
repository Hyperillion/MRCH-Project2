using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class TransparencyOnDistance : MonoBehaviour
{
    public bool limitation;
    public float limitationUpperBound;
    public float limitationLowerBound;

    public enum DistanceOptions
    {
        Xaxis,
        Zaxis,
    }
    public DistanceOptions selectedAxis;

    public float startPosition;
    public float endPosition;
    public float keepPositionStart;
    public float keepPositionEnd;
    public bool DebugMode;

    private float transparency;
    private float position;
    private float limitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePosition();
        UpdateTransparency();
        ApplyTransparency();
        DebugOutput();
    }

    // Calculate position based on selected axis
    private void CalculatePosition()
    {
        if (selectedAxis == DistanceOptions.Xaxis)
        {
            position = Camera.main.transform.position.x;
            limitPosition = Camera.main.transform.position.z;
        }
        else if (selectedAxis == DistanceOptions.Zaxis)
        {
            position = Camera.main.transform.position.z;
            limitPosition = Camera.main.transform.position.x;
        }
    }

    // Calculate transparency based on position and limits
    private void UpdateTransparency()
    {
        if (position < startPosition)
        {
            transparency = 0;
        }
        else if (position < keepPositionStart)
        {
            transparency = (position - startPosition) / (keepPositionStart - startPosition);
        }
        else if (position < keepPositionEnd)
        {
            transparency = 1;
        }
        else if (position < endPosition)
        {
            transparency = 1 - (position - keepPositionEnd) / (endPosition - keepPositionEnd);
        }
        else
        {
            transparency = 0;
        }

        // Apply limitation bounds: in the limitation bounds, the transparency will never be 0
        if (limitation && (limitPosition <= limitationUpperBound && limitPosition >= limitationLowerBound))
        {
            if (position > keepPositionEnd){
                transparency = 1;
            }
        }
    }

    // Set the transparency on the object's material
    private void ApplyTransparency()
    {
        Color color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, transparency);
    }

    // Debug output if DebugMode is enabled
    private void DebugOutput()
    {
        if (DebugMode)
        {
            Debug.Log("Selected Axis: " + selectedAxis);
            Debug.Log("Transparency: " + transparency);
            Debug.Log("Position: " + position);
            Debug.Log("Limit Position: " + limitPosition);
        }
    }
}
