using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        name.text = unit.name;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }
}
