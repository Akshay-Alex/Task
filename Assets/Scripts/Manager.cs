using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public List<Switch> switches;
    public GameObject ConditionPassed;
    public GameObject ConditionFailed;
    public void Reset()
    {
        ConditionPassed.SetActive(false);
        ConditionFailed.SetActive(false);
        foreach (Switch switchButton in switches)
        {
            foreach(Toggle toggle in switchButton.toggleUIReferences)
            {
                toggle.isOn = false;
            }
        }
    }
    private void Start()
    {
        Instance = this;
        Reset();
    }
    public void ShowConditionFailed()
    {
        ConditionFailed.SetActive(true);
        Debug.Log("failed");
    }
    public void ShowConditionPassed()
    {
        ConditionPassed.SetActive(true);
        Debug.Log("passed");
    }
}
