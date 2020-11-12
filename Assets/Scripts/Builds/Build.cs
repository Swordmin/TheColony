using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Build : MonoBehaviour
{

    [SerializeField] private BuildType _buildType;
    [SerializeField] private BuildState _buildState;
    [SerializeField] private BuildC _build = null;
    [SerializeField] private GameObject _ui = null;

    private void Start()
    {
        
    }
    private void Update()
    {

        var size = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        size = Mathf.Clamp(size,0.1f, 0.3f);
        if (_ui.GetComponent<UIPanelBuild>().SetTarget() == this)
        {
            _ui.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            _ui.transform.localScale = new Vector3(size, size, 1);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetPanelUIRes();
        }
    }
    public void SetBuild(BuildC __buildC) 
    {
        _build = __buildC;
    }
    public void SetBuildState(BuildState __buildState) 
    {
        _buildState = __buildState;
    }
    public BuildC SetBuild() => _build;
    public void GetBuild(BuildC _buildC) => _build = _buildC;
    public void GetUIStorage(GameObject __ui) => _ui = __ui;
    public void SetPanelUIRes() 
    {
        for (int i = 0; i < _build.SetMaxStoragePlace(PutItemCanType.Tool); i++) 
        {
            if (_build.GetStorage(PutItemCanType.Tool, i) != null)
            {
                //Debug.Log((Tool)_build.GetStorage(PutItemCanType.Tool, 1));
                Tool _tool = (Tool)_build.GetStorage(PutItemCanType.Tool, i);
                switch (_tool.ToString())
                {
                    case "Axe":
                        _ui.GetComponent<UIPanelBuild>().SetTool(0, 1);
                        break;
                    case "PickAxe":
                        _ui.GetComponent<UIPanelBuild>().SetTool(1, 1);
                        break;
                }
            }
        }
        for (int i = 0; i < _build.SetMaxStoragePlace(PutItemCanType.Food); i++)
        {
            if (_build.GetStorage(PutItemCanType.Food, i) != null)
            {
                //Debug.Log((Tool)_build.GetStorage(PutItemCanType.Tool, 1));
                Food _food = (Food)_build.GetStorage(PutItemCanType.Food, i);
                switch (_food.ToString())
                {
                    case "Apple":
                        _ui.GetComponent<UIPanelBuild>().SetFood(0, 1);
                        break;
                    case "Barry":
                        _ui.GetComponent<UIPanelBuild>().SetFood(1, 1);
                        break;
                }
            }
        }
    }
    public void ClearPanelUIRes() 
    {
        
    }

    private void OnMouseDown()
    {
        if (_ui.GetComponent<UIPanelBuild>().SetTarget() == this)
        {
            _ui.SetActive(_ui.activeSelf ? false : true);
        }
        else 
        {
            _ui.SetActive(true);
            _ui.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            _ui.GetComponent<UIPanelBuild>().GetTarget(this);
        }
    }
}
