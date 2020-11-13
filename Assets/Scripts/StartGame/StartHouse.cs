using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Build))]
public class StartHouse : MonoBehaviour
{

    private Build _buildEx;

    void Start()
    {
        _buildEx = GetComponent<Build>();
        _buildEx.GetBuild(new BuildC(BuildType.House, BuildSize.Normal, BuildMaterial.Wood, 100, 1, 8, 5, 20, 20,10));
        _buildEx.SetBuild().PutStorage(new Axe(new Iron(),10), PutItemCanType.Tool);
        _buildEx.SetBuild().PutStorage(new Axe(new Stone(),10), PutItemCanType.Tool);
        _buildEx.SetBuild().PutStorage(new PickAxe(new Iron(), 10), PutItemCanType.Tool);
        _buildEx.SetBuild().PutStorage(new PickAxe(new Stone(), 10), PutItemCanType.Tool);
        for (int i = 0; i < 20; i++) 
        {
            _buildEx.SetBuild().PutStorage(new Apple(), PutItemCanType.Food);
        }
        for (int i = 0; i < 3; i++) 
        {
            _buildEx.SetBuild().PutStorage(new BuildWood(), PutItemCanType.Material);
        }
        for (int i = 0; i < 3; i++)
        {
            _buildEx.SetBuild().PutStorage(new BuildStone(), PutItemCanType.Material);
        }
        for (int i = 0; i < 4; i++)
        {
            _buildEx.SetBuild().PutStorage(new Iron(), PutItemCanType.Material);
        }

    }


}
