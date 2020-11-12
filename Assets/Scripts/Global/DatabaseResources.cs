using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseResources : MonoBehaviour
{
    public DatabaseResources _instance;
    [SerializeField] private int _woodRes;
    [SerializeField] private int _stoneRes;
    [SerializeField] private int _metalRes;
    [SerializeField] private int _spriteResCount => System.IO.Directory.GetFiles("Assets/Resources/Food").Length/2;

    private void Start()
    {
    }
}
