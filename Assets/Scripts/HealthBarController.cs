using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{

    private Transform healthBarInside;
    private Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        healthBarInside = transform.GetChild(0);
        defaultScale = healthBarInside.localScale;
    }

    public void UpdateHealth(float value, float max)
    {
        Vector3 newScale = defaultScale;
        newScale.x = newScale.x * value/max;
        healthBarInside.localScale = newScale;
    }
}
