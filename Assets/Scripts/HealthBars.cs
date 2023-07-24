using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBars : MonoBehaviour
{
    public Slider slider;
    Camera main;
    public TextMeshProUGUI healthText;
    public float yAxisOffset=1;

    private void Awake()
    {
        main = Camera.main;
        slider = GetComponentInChildren<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        slider.transform.position = main.WorldToScreenPoint(transform.parent.position + (Vector3.up * yAxisOffset));

    }

    private void Update()
    {
        slider.transform.position = main.WorldToScreenPoint(transform.parent.position+(Vector3.up* yAxisOffset));

    }

}
