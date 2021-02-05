using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : MonoBehaviour
{
    public Light light;
    public GameObject lightModel;
    public Material lightMaterial;

    public int burstAmmount = 3;

    public float burstDelay = 0.1f;
    public float flickerTimes = float.MaxValue;
    public float flickerDelay = 0.5f;
    public float defIntensity;

    float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        lightMaterial = lightModel.GetComponent<Renderer>().materials[0];
        defIntensity = light.intensity;
        StartCoroutine(flickerStuff());
    }

  void lightOn()
    {
        light.intensity = defIntensity;
        lightMaterial.EnableKeyword("_EMISSION");
        Debug.Log("light on");
    }

    void lightOff()
    {
        light.intensity = 0.5f;
        lightMaterial.DisableKeyword("_EMISSION");
        Debug.Log("light off");
    }

    IEnumerator FireCourorine()
    {
        for (int k = 0; k < burstAmmount; k++)
        {
            lightOn();
            yield return new WaitForSeconds(burstDelay);
            lightOff();
            yield return new WaitForSeconds(burstDelay);
            lightOn();
        }
    }

  IEnumerator flickerStuff()
    {
        for(int i = 0; i < flickerTimes; i++)
        {
            yield return new WaitForSeconds(flickerDelay);
            StartCoroutine(FireCourorine());
        }
    }
}
