using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
public class ManaManager : NetworkBehaviour
{

    public float  currentMana;
    public float maxMana = 10;
    public float manaPerSecond = 2.8f;

    int mana;

  //  public Slider  UIManager.Instance.manaSlider;
   // public TextMeshProUGUI manaText;
  //  public TextMeshProUGUI UIManager.Instance.notEnoughManaText;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
            return;

      
     



        mana = Mathf.FloorToInt(currentMana);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;

  

        if (mana == maxMana)
            return;
        currentMana += Time.deltaTime / manaPerSecond;
         UIManager.Instance.manaSlider.value = currentMana / maxMana;
        if (mana < Mathf.FloorToInt(currentMana))
        {
            mana = Mathf.FloorToInt(currentMana);
            ChangeUIValues();
        }

    }

    public void SpendMana(float amount)
    {
        currentMana -= amount;
        mana = Mathf.FloorToInt(currentMana);
        UIManager.Instance.manaText.text = "" + mana;
    }

    public void ChangeUIValues()
    {
        UIManager.Instance.manaText.text = "" + mana;
        UIManager.Instance.manaText.transform.DOScale(1.3f, 0.3f).OnComplete(ResetTextTween);
         UIManager.Instance.manaSlider.transform.DOScale(1.01f, 0.3f);
    }
    void ResetTextTween()
    {
        UIManager.Instance.manaText.transform.DOScale(1f, 0.4f);
         UIManager.Instance.manaSlider.transform.DOScale(1f, 0.3f);
        UIManager.Instance.notEnoughManaText.enabled = false;
    }

    public void NotEnoughMana()
    {
        UIManager.Instance.manaText.transform.DOShakeScale(0.5f, 0.5f).OnComplete(ResetTextTween);
         UIManager.Instance.manaSlider.transform.DOShakeScale(0.5f, 0.5f);
        UIManager.Instance.notEnoughManaText.enabled = true;
    }



}
