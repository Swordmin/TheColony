using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PutItemCanType
{
    Tool = 0,
    Food = 1,
    Material = 2,
    Cloth = 3
}

public enum BuildSize 
{
    Small = 0,
    Normal = 1,
    Big = 2
}

public enum BuildType
{

    House = 0,
    Farm = 1,
    Production = 2,
    Storage

}

public enum BuildMaterial 
{

    Wood = 0,
    Stone = 1

}

public enum BuildState 
{
    Carryng = 0,
    Procces = 1,
    Final = 2

}

public class BuildC
{

    private BuildType _buildType;
    private BuildMaterial _buildMaterial;
    private BuildSize _buildSize;
    private ITool[] _toolStorage;
    private IFood[] _foodStorage;
    private IMaterialBuild[] _materialStorage;
    private ICloth[] _clothStorage;
    private Axe[] _axe = new Axe[1] { new Axe(null, 0) };

    public float _health;
    private float _burningRate;
    private int _livingPlaces;


    public BuildC(BuildType __buildType, BuildSize __buildSize, BuildMaterial __buildMaterial, float __health, float __burningRate, int __livingPlaces, int __toolsStorage, int __foodStorage, int __materialStorage, int __clothStorage)
    {
        _buildType = __buildType;
        _buildMaterial = __buildMaterial;
        _buildSize = __buildSize;
        _health = __health;
        _burningRate = __burningRate;
        _livingPlaces = __livingPlaces;
        _toolStorage = new ITool[__toolsStorage];
        _foodStorage = new IFood[__foodStorage];
        _materialStorage = new IMaterialBuild[__materialStorage];
        _clothStorage = new ICloth[__clothStorage];
    }

    public BuildC(BuildType __buildType, BuildSize __buildSize, BuildMaterial __buildMaterial, float __health, float __burningRate, int __livingPlaces, int __toolsStorage, int __foodStorage, int __clothStorage)
    {
        _buildType = __buildType;
        _buildMaterial = __buildMaterial;
        _buildSize = __buildSize;
        _health = __health;
        _burningRate = __burningRate;
        _livingPlaces = __livingPlaces;
        _toolStorage = new ITool[__toolsStorage];
        _foodStorage = new IFood[__foodStorage];
        _clothStorage = new ICloth[__clothStorage];
    }

    public bool PutStorage(IItemHouse _item, PutItemCanType _typeStorage) 
    {
        switch (_typeStorage) 
        {
            case PutItemCanType.Cloth:
                for (int i = 0; i < _clothStorage.Length; i++) 
                {
                    if (_clothStorage[i] == null) 
                    {
                        _clothStorage[i] =  (ICloth)_item;
                        return true;
                    }
                }
                break;
            case PutItemCanType.Tool:
                for (int i = 0; i < _toolStorage.Length; i++)
                {
                    if (_toolStorage[i] == null)
                    {
                        _toolStorage[i] = (ITool)_item;
                        return true;
                    }
                }
                break;
            case PutItemCanType.Material:
                for (int i = 0; i < _materialStorage.Length; i++)
                {
                    if (_materialStorage[i] == null)
                    {
                        _materialStorage[i] = (IMaterialBuild)_item;
                        return true;
                    }
                }
                break;
            case PutItemCanType.Food:
                for (int i = 0; i < _foodStorage.Length; i++)
                {
                    if (_foodStorage[i] == null)
                    {
                        _foodStorage[i] = (IFood)_item;
                        return true;
                    }
                }
                break;
        }
        return false;   
    }
    public IItemHouse GetStorage(PutItemCanType _typeStorage, int _id) 
    {
        switch (_typeStorage)
        {
            case PutItemCanType.Cloth:
                    return (IItemHouse)_clothStorage[_id];
            case PutItemCanType.Tool:
                    return (IItemHouse)_toolStorage[_id];
            case PutItemCanType.Material:
                    return (IItemHouse)_materialStorage[_id];
            case PutItemCanType.Food:
                    return (IItemHouse)_foodStorage[_id];
        }
        return null;
    }
    public int SetMaxStoragePlace(PutItemCanType _type)
    {
        switch (_type) 
        {
            case PutItemCanType.Cloth:
                return _clothStorage.Length;
            case PutItemCanType.Food:
                return _foodStorage.Length;
            case PutItemCanType.Material:
                return _materialStorage.Length;
            case PutItemCanType.Tool:
                return _toolStorage.Length;
        }
        return 0;
    }
}
