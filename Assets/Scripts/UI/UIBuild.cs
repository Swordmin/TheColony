using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuild : MonoBehaviour
{

   [Tooltip("0 House, 1 Farm, 2 Product")] [SerializeField] private BuildType _buildType = 0;
   [Tooltip("0 Small, 1 Normal, 2 Big")] [SerializeField] private BuildSize _buildSize = 0;
   [Tooltip("0 Wood, 1 Stone")][SerializeField] private BuildMaterial _buildMaterial = 0;

   [SerializeField] private GameObject[] _butHouseSize = new GameObject[2];
   [SerializeField] private GameObject[] _butHouseMaterial = new GameObject[1];

   


    public void SetBuildType (int __buildType) 
    {
        _buildType = (BuildType)__buildType;
    }
    public void SetBuildSize(int __buildSize)
    {
        _buildSize = (BuildSize)__buildSize;
    }
    public void SetBuildMaterial(int __buildMaterial)
    {
        _buildMaterial = (BuildMaterial)__buildMaterial;
    }

    public void SetTypedHouse() 
    {
        for (int i = 0; i < _butHouseSize.Length; i++)
            _butHouseSize[i].SetActive(true);
        for (int i = 0; i < _butHouseMaterial.Length; i++)
            _butHouseMaterial[i].SetActive(false);
    }
    public void SetSizeHouse() 
    {
        for (int i = 0; i < _butHouseSize.Length; i++)
            _butHouseSize[i].SetActive(false);
        for (int i = 0; i < _butHouseMaterial.Length; i++)
            _butHouseMaterial[i].SetActive(true);
    }
    public void SetMaterialHouse() 
    {
        for (int i = 0; i < _butHouseMaterial.Length; i++)
            _butHouseMaterial[i].SetActive(false);
        FinalOrder();
    }

    private void FinalOrder() 
    {
        BuildControll._instance.SetMeshTemplate(GetMeshTemplate());
        BuildControll._instance.SetBuildProject(GetBuildHouse());
        BuildControll._instance.SetColliderTemplate(GetColliderTemplate());
    }

    public BuildC GetBuildHouse() 
    {
        return new BuildC(_buildType, _buildSize, _buildMaterial, GetHealth(), GetBurningRate(), GetLivingPlaces(), GetToolsStorage(), GetFoodStorage(), GetClothlStorage());
    }

    ///<returns> Return health for build depending on type, size and material.</returns>
    public float GetHealth() 
    {
        float _health = 0;
        switch (_buildType) 
        {
            case BuildType.House:
                _health += 5;
                break;
            case BuildType.Farm:
                _health += 2;
                break;
            case BuildType.Production:
                _health += 10;
                break;
        }
        switch (_buildSize) 
        {
            case BuildSize.Small:
                _health += 5;
                break;
            case BuildSize.Normal:
                _health += 10;
                break;
            case BuildSize.Big:
                _health += 20;
                break;
        }
        switch (_buildMaterial) 
        {
            case BuildMaterial.Stone:
                _health += 40;
                break;
            case BuildMaterial.Wood:
                _health += 20;
                break;
        }
        return _health;
    }
    ///<returns> Return burning rate for build depending on material.</returns>
    public float GetBurningRate() 
    {
        float _burningRate = 0;
        switch (_buildMaterial) 
        {
            case BuildMaterial.Stone:
                _buildMaterial += 20;
                break;
            case BuildMaterial.Wood:
                _buildMaterial += 50;
                break;
        }
        return _burningRate;
    }
    ///<returns> Return living places for build depending on size.</returns>
    public int GetLivingPlaces() 
    {
        int _livingPlaces = 0;
        switch (_buildSize) 
        {
            case BuildSize.Small:
                _livingPlaces += 4;
                break;
            case BuildSize.Normal:
                _livingPlaces += 6;
                break;
            case BuildSize.Big:
                _livingPlaces += 10;
                break;
        }
        return _livingPlaces;
    }
    ///<returns> Return tools storage for build depending on size, type.</returns>
    public int GetToolsStorage() 
    {
        int _toolsStorage = 0;
        switch (_buildType) 
        {
            case BuildType.Production:
                _toolsStorage += 3;
                break;
            case BuildType.Storage:
                _toolsStorage += 5;
                break;
        }
        switch (_buildSize) 
        {
            case BuildSize.Small:
                if (_buildType == BuildType.Storage)
                    _toolsStorage += 5;
                else
                    _toolsStorage += 1;
                break;
            case BuildSize.Normal:
                if (_buildType == BuildType.Storage)
                    _toolsStorage += 8;
                else
                    _toolsStorage += 2;
                break;
            case BuildSize.Big:
                if (_buildType == BuildType.Storage)
                    _toolsStorage += 15;
                else
                    _toolsStorage += 5;
                break;
        }
        return _toolsStorage;
    }
    ///<returns> Return tools storage for build depending on size, type.</returns>
    public int GetFoodStorage()
    {
        int _foodStorage = 0;
        switch (_buildType)
        {
            case BuildType.House:
                _foodStorage += 5;
                break;
            case BuildType.Storage:
                _foodStorage += 20;
                break;
        }
        switch (_buildSize)
        {
            case BuildSize.Small:
                if (_buildType == BuildType.Storage)
                    _foodStorage += 10;
                else
                    _foodStorage += 5;
                break;
            case BuildSize.Normal:
                if (_buildType == BuildType.Storage)
                    _foodStorage += 15;
                else
                    _foodStorage += 10;
                break;
            case BuildSize.Big:
                if (_buildType == BuildType.Storage)
                    _foodStorage += 25;
                else
                    _foodStorage += 15;
                break;
        }
        return _foodStorage;
    }
    ///<returns> Return material storage for build depending on size, type.</returns>
    public int GetMaterialStorage()
    {
        int _materialStorage = 0;
        switch (_buildType)
        {
            case BuildType.Storage:
                _materialStorage += 20;
                break;
        }
        switch (_buildSize)
        {
            case BuildSize.Small:
                if (_buildType == BuildType.Storage)
                    _materialStorage += 10;
                else if (_buildType == BuildType.Production)
                    _materialStorage += 5;
                break;
            case BuildSize.Normal:
                if (_buildType == BuildType.Storage)
                    _materialStorage += 20;
                else if (_buildType == BuildType.Production)
                    _materialStorage += 10;
                break;
            case BuildSize.Big:
                if (_buildType == BuildType.Storage)
                    _materialStorage += 35;
                else if (_buildType == BuildType.Production)
                    _materialStorage += 10;
                break;
        }
        return _materialStorage;
    }
    ///<returns> Return cloth storage for build depending on size, type.</returns>
    public int GetClothlStorage()
    {
        int _clothStorage = 0;
        switch (_buildType)
        {
            case BuildType.Storage:
                _clothStorage += 20;
                break;
        }
        switch (_buildSize)
        {
            case BuildSize.Small:
                if (_buildType == BuildType.Storage)
                    _clothStorage += 5;
                else if (_buildType == BuildType.Production)
                    _clothStorage += 0;
                break;
            case BuildSize.Normal:
                if (_buildType == BuildType.Storage)
                    _clothStorage += 10;
                else if (_buildType == BuildType.Production)
                    _clothStorage += 0;
                break;
            case BuildSize.Big:
                if (_buildType == BuildType.Storage)
                    _clothStorage += 15;
                else if (_buildType == BuildType.Production)
                    _clothStorage += 0;
                break;
        }
        return _clothStorage;
    }
    ///<returns> Return mesh build for build depending on size, type.</returns>
    public Mesh GetMeshTemplate() 
    {
        switch(_buildType)
        {
        
            case BuildType.House:
                return BuildControll._instance.GetMeshHouse(_buildSize,0);        

        }
        return null;
    }
    ///<returns> Return boxCollider build for build depending on size, type.</returns>
    public BoxCollider GetColliderTemplate() 
    {
        switch (_buildType) 
        {
            case BuildType.House:
                return BuildControll._instance.GetColliderHouse(_buildSize, 0);

        }
        return null;
    }
}
