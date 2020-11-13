using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanelBuild : MonoBehaviour
{

    [SerializeField] private GameObject _templateResCount;
    [SerializeField] private Build _target;
    [SerializeField] private int[] _foodCount = new int[2];
    [SerializeField] private int[] _resourcesCount = new int[3];
    [SerializeField] private int[] _toolCount = new int[2];
    [SerializeField] private Image[] _foodImage = new Image[2];
    [SerializeField] private Image[] _resourcesImage = new Image[3];
    [SerializeField] private Image[] _toolsImage = new Image[2];
    [SerializeField] private TextMeshProUGUI[] _foodText = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI[] _resourcesText = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] _toolsText = new TextMeshProUGUI[2];

    public void AddItem(BuildC _build) 
    {
        
    }

    public void GetTarget(Build _build) => _target = _build;
    public Build SetTarget() => _target;
    public void SetFood(int id, int _count) 
    {
        _foodCount[id] += _count;
        _foodText[id].text = _foodCount[id].ToString();
    }
    public void SetResources(int id, int _count)
    {
        _resourcesCount[id] += _count;
        _resourcesText[id].text = _resourcesCount[id].ToString();
    }
    public void SetTool(int id, int _count)
    {
        _toolCount[id] += _count;
        Debug.Log(_toolCount[id]);
        _toolsText[id].text = _toolCount[id].ToString();
    }
    public void Clear() 
    {
        for (int i = 0; i < _foodText.Length; i++)
        {
            _foodCount[i] = 0;
            _foodText[i].text = _foodCount[i].ToString();
        }
        for (int i = 0; i < _resourcesText.Length; i++)
        {
            _resourcesCount[i] = 0;
            _resourcesText[i].text = _resourcesCount[i].ToString();
        }
        for (int i = 0; i < _toolsText.Length; i++)
        {
            _toolCount[i] = 0;
            _toolsText[i].text = _toolCount[i].ToString();
        }
    }
}
