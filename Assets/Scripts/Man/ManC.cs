public enum Profession 
{
    Noone = 0,
    Bilder = 1,
    Farmer = 2,
    Lumberjack = 3,
    Miner = 4,
    Artisan = 5

}
public enum Gender 
{

    Male = 0,
    Female = 1

}
public enum AgeStage  
{
    Child = 0,
    Young = 1,
    Adult = 2,
    OldMan = 3
}
public enum ManState 
{
    noone = 0,
    Work = 1,
    Resting = 2,
    Care = 3
}

public class ManC 
{
    private string _name;
    private float _hunger;
    private Gender _gender;
    private AgeStage _ageStage;
    private Profession _proffesion;
    private int[] _proffesionLevel = new int[7]; // 0 = WoodJob, 1 = StoneJob, 2 = Farmer, 3 = Cook, 4 = Hunter, 5 = Builder, 6 - Researcher;
    private Item _itemHand;
    private ITool _tool;
    private ICloth[] _cloth = new ICloth[5];

    public ManC(string __name, Gender __gender, AgeStage __ageStage, Profession __proffesion) 
    {
        _name = __name;
        _gender = __gender;
        _ageStage = __ageStage;
        _proffesion = __proffesion;
    }

    public string GetName() 
    {
        return _name;
    }
    public string GetGender() 
    {
        return _gender.ToString();
    }
    public string GetProfessionName()
    {
        return _proffesion.ToString();
    }
    public float GetHunger() 
    {
        return _hunger;
    }
    public void SetHunger(float _satiety) 
    {
        _hunger -= _satiety;
    }
}
