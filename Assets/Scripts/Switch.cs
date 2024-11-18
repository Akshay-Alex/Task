using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public List<Toggle> toggleUIReferences;
    public List<bool> Currentconditions;
    public List<bool> validConditions;
    

   public void CheckSwitchConditions()
    {
        int index = 0;
        foreach(bool data in validConditions)
        {

            if(validConditions[index] != Currentconditions[index])
            {
                Manager.Instance.ShowConditionFailed();
                return;
            }
            index++;
        }
        Manager.Instance.ShowConditionPassed();
    }

    public void ToggleValueChanged()
    {
        Currentconditions.Clear();
        foreach( Toggle toggle in toggleUIReferences)
        {
            Currentconditions.Add(toggle.isOn);
        }
    }
    private void Start()
    {
        ToggleValueChanged();
    }
}
