using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTime : MonoBehaviour
{
    public Text dateTimeTxt;

    private void Start()
    {
        dateTimeTxt.text = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy  HH: mm");
    }
}
