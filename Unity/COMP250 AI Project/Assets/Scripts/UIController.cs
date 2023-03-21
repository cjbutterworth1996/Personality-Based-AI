using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Class <c>UIController</c> is used to handle all UI functionality.
/// </summary>
public class UIController : MonoBehaviour
{
    public ProgressBar bladderBar; // The bladder progress bar.
    public ProgressBar boredomBar; // The boredom progress bar.
    public ProgressBar energyBar; // The energy progress bar.
    public ProgressBar hungerBar; // The hunger progress bar.
    public ProgressBar thirstBar; // The thirst progress bar.
    public Label moneyCounter; // The money counter.
    public UIDocument uiDoc; // The UIDocument in which these progress bars are stored.

    int defaultValue; // The default value of each bar.

    /// <summary>
    /// Method <c>Start</c> is called before the first frame.
    /// </summary>
    void Start()
    {
        this.enabled = true; //Ensures this script is enabled.
        uiDoc = GetComponent<UIDocument>();
        defaultValue = 100;
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

        UpdateMoney(defaultValue);
    }

    /// <summary>
    /// Method <c>UpdateMoney</c> updates the money counter UI element.
    /// </summary>
    /// <param name="updateAmount"></param>
    public void UpdateMoney(int updateAmount)
    {
        moneyCounter.text = "Money: " + updateAmount.ToString();
    }
}
