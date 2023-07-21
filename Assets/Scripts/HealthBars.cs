using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBars : MonoBehaviour
{
    public Slider slider;
    Camera main;

    public float yAxisOffset=1;

    private void Awake()
    {
        main = Camera.main;
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.transform.position = main.WorldToScreenPoint(transform.parent.position+(Vector3.up* yAxisOffset));
    }

}
