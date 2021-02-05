using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressTracker : MonoBehaviour
{
    public float max;
    public float current;
    public float min;
    public Image mask;
    public Image fill;
    public Color colour;

    private void Update()
    {
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;

        mask.fillAmount = fillAmount;

        fill.color = colour;
    }
}
