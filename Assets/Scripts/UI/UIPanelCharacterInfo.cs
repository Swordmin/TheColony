using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPanelCharacterInfo : MonoBehaviour
{

    public static UIPanelCharacterInfo _instance = null;

    [SerializeField] private TextMeshProUGUI _name = null;
    [SerializeField] private TextMeshProUGUI _gender = null;
    [SerializeField] private TextMeshProUGUI _proffesion = null;
    [SerializeField] private TextMeshProUGUI _employment = null;

    private void Start()
    {
        _instance = this;
    }

    public void SetParam(ManC _man) 
    {
        _name.text = _man.GetName();
        _gender.text = _man.GetGender();
        _proffesion.text = _man.GetProfessionName();
    }
}
