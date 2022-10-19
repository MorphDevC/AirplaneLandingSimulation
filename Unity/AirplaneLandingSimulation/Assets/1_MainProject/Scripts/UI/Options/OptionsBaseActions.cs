using System;
using UnityEngine;

[RequireComponent(typeof(OptionsInfo))]
public class OptionsBaseActions:MonoBehaviour
{
    private OptionsInfo _optionsInfoRef;

    private void Awake()
    {
        _optionsInfoRef = GetComponent<OptionsInfo>();
    }

    public void RefreshSettingsValues()
    {
        _optionsInfoRef.GetSliders.ForEach(option =>
        {
            option.RefreshValues();
        });
    }
}
