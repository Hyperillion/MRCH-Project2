using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class YearChange : MonoBehaviour
{
    public float pos1;
    public float pos2;
    public float pos3;
    public float pos4;
    public float pos5;
    public int year1;
    public int year2;
    public int year3;
    public int year4;
    public int year5;
    public int currentYear;
    private TextMeshProUGUI yearText;
    private Vector3 position;
    private float startPosition;
    void Start()
    {
        startPosition = Camera.main.transform.position.z;
        yearText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePosition();
        UpdateYear();
        // Debug.Log(position);
    }

    private void CalculatePosition()
    {
        position = Camera.main.transform.position;
    }

    private void UpdateYear()
    {
        if (position.z < pos1 || position.x > -150)
        {
            //calculate the year according to the position
            currentYear = limitMap(position.z, startPosition, pos1, 2024, year1);
        }
        else if (position.z < pos2)
        {
            currentYear = limitMap(position.z, pos1, pos2, year1, year2);
        }
        else if (position.z < pos3)
        {
            currentYear = limitMap(position.z, pos2, pos3, year2, year3);
        }
        else if (position.z < pos4)
        {
            currentYear = limitMap(position.z, pos3, pos4, year3, year4);
        }
        else if (position.z < pos5)
        {
            currentYear = limitMap(position.z, pos4, pos5, year4, year5);
        }
        yearText.text = currentYear.ToString();
    }

    private int limitMap(float value, float start1, float stop1, float start2, float stop2)
    {
        value = Mathf.Clamp(value, start1, stop1);
        return (int)(start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1)));
    }
}
