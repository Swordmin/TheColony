using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCheck : MonoBehaviour
{

    [SerializeField] private bool can = true;
    Ray _rayLeft;

    public bool IsPlaceFree() 
    {
        return can;
    }


    private void OnTriggerEnter(Collider other)
    {
        can = false;
        GetComponentInChildren<MeshRenderer>().material = BuildControll._instance.GetMaterialPlaceDFree();
    }
    private void OnTriggerExit(Collider other)
    {
        can = true;
        GetComponentInChildren<MeshRenderer>().material = BuildControll._instance.GetMaterialPlaceFree();
    }

}
