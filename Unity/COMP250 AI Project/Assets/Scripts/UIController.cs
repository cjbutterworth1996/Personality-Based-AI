using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public ProgressBar bladderBar;
    public ProgressBar boredomBar;
    public ProgressBar energyBar;
    public ProgressBar hungerBar;
    public ProgressBar thirstBar;
    public Label moneyCounter;
    private int defaultValue = 100;
    public UIDocument uiDoc;

    void Start()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        bladderBar = uiDoc.rootVisualElement.Q<ProgressBar>("BladderBar");
        boredomBar = uiDoc.rootVisualElement.Q<ProgressBar>("BoredomBar");
        energyBar = uiDoc.rootVisualElement.Q<ProgressBar>("EnergyBar");
        hungerBar = uiDoc.rootVisualElement.Q<ProgressBar>("HungerBar");
        thirstBar = uiDoc.rootVisualElement.Q<ProgressBar>("ThirstBar");
        moneyCounter = uiDoc.rootVisualElement.Q<Label>("MoneyCounter");
        bladderBar.value = defaultValue;
        boredomBar.value = defaultValue;
        energyBar.value = defaultValue;
        hungerBar.value = defaultValue;
        thirstBar.value = defaultValue;
        moneyCounter.text = "Money: " + defaultValue.ToString();
    }

    public void UpdateBladder(int updateAmount)
    {
        bladderBar.value = updateAmount;
    }

    public void UpdateBoredom(int updateAmount)
    {
        boredomBar.value = updateAmount;
    }

    public void UpdateEnergy(int updateAmount)
    {
        energyBar.value = updateAmount;
    }

    public void UpdateHunger(int updateAmount)
    {
        hungerBar.value = updateAmount;
    }

    public void UpdateThirst(int updateAmount)
    {
        thirstBar.value = updateAmount;
    }

    public void UpdateMoney(int updateAmount)
    {
        moneyCounter.text = "Money: " + updateAmount.ToString();
    }
}
