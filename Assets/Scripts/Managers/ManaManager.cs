using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
public class ManaManager : Singleton<ManaManager>
{

    public float currentMana;
    public float maxMana=10;
    public float manaPerSecond=2.8f;

    int mana;

    public Slider manaSlider;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI notEnoughManaText;



    // Start is called before the first frame update
    void Start()
    {
        mana = Mathf.FloorToInt(currentMana); 
        manaText.text = "" + mana;
    }

    // Update is called once per frame
    void Update()
    {
        if (mana == maxMana)
            return;
        currentMana += Time.deltaTime/manaPerSecond;
        manaSlider.value = currentMana / maxMana;
        if (mana < Mathf.FloorToInt(currentMana) )
        {
            mana = Mathf.FloorToInt(currentMana) ;
            ChangeUIValues();
        }

    }

    public void SpendMana(float amount)
    {
        currentMana -= amount;
        mana= Mathf.FloorToInt(currentMana); 
        manaText.text = "" + mana;
    }

    public void ChangeUIValues()
    {
        manaText.text = ""+mana;
        manaText.transform.DOScale(1.3f, 0.3f).OnComplete(ResetTextTween);
        manaSlider.transform.DOScale(1.01f, 0.3f);
    }
    void ResetTextTween()
    {
        manaText.transform.DOScale(1f, 0.4f);
        manaSlider.transform.DOScale(1f, 0.3f);
        notEnoughManaText.enabled = false;
    }

    public void NotEnoughMana()
    {
        manaText.transform.DOShakeScale(0.5f,0.5f).OnComplete(ResetTextTween);
        manaSlider.transform.DOShakeScale(0.5f, 0.5f);
        notEnoughManaText.enabled = true;
    }


}
