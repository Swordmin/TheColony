using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItemHouse 
{

}
public interface IItem 
{
    string _name { get;}
    int _count { get;}

}


public interface IUse 
{
    float _strength { get; set; }
}

public interface IMaterialBuild
{

}

public interface IMaterialTool 
{
    int _qualityMaterial { get; set; }
}
public interface IMaterialCloth
{
    int _qualityMaterial { get; set; }
}


#region Material
public class Iron : MaterialBuild, IMaterialTool, IItemHouse
{
    public int _qualityMaterial { get { return 5; } set { _qualityMaterial = value; } }
}
public class Stone : IMaterialTool
{
    public int _qualityMaterial { get { return 2; } set { _qualityMaterial = value; } }
}
#endregion

#region MaterialBuild
public class MaterialBuild : IMaterialBuild, IItemHouse
{

}
public class BuildWood : MaterialBuild 
{
}
public class BuildStone : MaterialBuild 
{
}

#endregion

#region Tool

public enum ToolMaterial
{
    Wood = 0,
    Stone = 1,
    Metall = 2
}

public enum ToolType
{
    Miner = 0,
    Lamberjack = 1,
    Atack = 2,
    Artisan = 3
}

public interface ITool 
{
    ToolType _toolType { get; set; }
    int _quality { get; set; }
}

public class Tool : IItem, ITool, IUse, IItemHouse
{
    public float _strength { get; set; }
    public string _name { get { return "";} set { } }
    public int _count { get; set; }
    public ToolType _toolType { get; set; }
    public IMaterialTool _toolMaterial { get; set; }
    public int _quality { get; set; }
    public int SetQuality(int _exp, IMaterialTool _material) => _quality = _exp += _material._qualityMaterial;
    public void SetName(string __name) 
    {
        _name = __name;
    }
}

public class Axe : Tool
{
    public string GetName() => _name;
    public Axe(IMaterialTool __toolMaterial, int __quality) 
    {
        SetName("Axe");
        _toolMaterial = __toolMaterial;
        _quality = __quality;
    }

}

public class PickAxe : Tool
{
    public string GetName() => _name;
    public PickAxe(IMaterialTool __toolMaterial, int __quality)
    {
        SetName("PickAxe");
        _toolMaterial = __toolMaterial;
        _quality = __quality;
    }

}
#endregion


#region Cloth
public class Cloth: IItem, ICloth, IUse, IItemHouse
{
    public string GetName() => _name;
    public float _strength { get; set; }
    public float _warmly { get; set; }
    public IMaterialCloth _clothMaterial { get; set; }
    public int _quality { get; set; }
    public string _name { get; set; }
    public int _count { get; set; }
    public int _defense { get; set; }
    public int SetQuality(int _exp, IMaterialCloth _material) => _quality = _exp += _material._qualityMaterial;
}

public class Hat : Cloth
{
    public Hat(float __strength, float __warmly, IMaterialCloth __clothMaterial, int __quality) 
    {
        _name = "Hat";
        _strength = __strength;
        _warmly = __warmly;
        _clothMaterial = __clothMaterial;
        _quality = __quality;
    }
}
public class Bib : Cloth
{
    public Bib(float __strength, float __warmly, IMaterialCloth __clothMaterial, int __quality)
    {
        _name = "Bib";
        _strength = __strength;
        _warmly = __warmly;
        _clothMaterial = __clothMaterial;
        _quality = __quality;
    }
}
public class Pants : Cloth
{
    public Pants(float __strength, float __warmly, IMaterialCloth __clothMaterial, int __quality)
    {
        _name = "Pants";
        _strength = __strength;
        _warmly = __warmly;
        _clothMaterial = __clothMaterial;
        _quality = __quality;
    }
}
public class Boots : Cloth
{
    public Boots(float __strength, float __warmly, IMaterialCloth __clothMaterial, int __quality)
    {
        _name = "Boots";
        _strength = __strength;
        _warmly = __warmly;
        _clothMaterial = __clothMaterial;
        _quality = __quality;
    }
}

public interface ICloth 
{
    float _warmly { get; set; }
    IMaterialCloth _clothMaterial { get; set; }
    int _quality { get; set; }
    int _defense { get; set; }
}
#endregion

#region Food

public interface IFood 
{
    float _satiety { get; set; }
    void Eat(ManC _man);
}

public class Food : IItem, IFood, IItemHouse
{
    public  string _name { get; set; }
    public int _count { get; }
    public float _satiety { get; set; }
    public void Eat(ManC _man) => _man.SetHunger(_satiety);
    public string GetName() => _name;
}

public class Apple : Food
{
    public Apple() 
    {
        _name = "Apple";
        _satiety = 5;
    }
}
public class Berry : Food
{
    public Berry()
    {
        _name = "Apple";
        _satiety = 2;
    }
}
#endregion


