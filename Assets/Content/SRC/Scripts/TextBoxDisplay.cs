using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxDisplay : MonoBehaviour
{
    private float transparency = 0;
    private bool isDisplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisplaying)
        {
            transparency = Mathf.Lerp(transparency, 1, 0.1f);
        }
        else
        {
            transparency = Mathf.Lerp(transparency, 0, 0.1f);
        }
        ApplyTransparency();
    }

    public void Display()
    {
        isDisplaying = true;
    }

    public void Hide()
    {
        isDisplaying = false;
    }

    private void ApplyTransparency()
    {
        Color color = GetComponent<UnityEngine.UI.Image>().color;
        color.a = transparency;
        GetComponent<UnityEngine.UI.Image>().color = color;
    }
}
