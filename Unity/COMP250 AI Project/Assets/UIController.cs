using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public ProgressBar thirstBar;
    private int thirst = 50;

    void Start()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        thirstBar = uiDoc.rootVisualElement.Q<ProgressBar>("ThirstBar");
        thirstBar.value = thirst;
    }

    public void UpdateThirst(int updateAmount)
    {
        thirst = updateAmount;
        thirstBar.value = thirst;
    }
}
