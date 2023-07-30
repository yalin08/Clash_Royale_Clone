using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    public UICard[] Cards; 
    public UICard NextCard;



    public Slider manaSlider;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI notEnoughManaText;



}
