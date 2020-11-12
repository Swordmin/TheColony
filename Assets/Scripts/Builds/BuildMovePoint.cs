using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMovePoint : MonoBehaviour
{

    [SerializeField] public GameObject _parent;
    private Vector3 _startPos;

    private Color _colorPoint = Color.green;

    public void OnDrawGizmos()
    {
        Gizmos.color = _colorPoint;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    private void Awake()
    {
        //BuildControll._instance._listBuildPoint.Add(this);
    }

    private void Start()
    {
        _startPos = transform.position;

        //BuildControll._instance._listBuildPoint.Add(this);
    }
    private void Update()
    {
 
        if (Input.GetKey(KeyCode.X)) 
        {
            foreach (BuildMovePoint _point in BuildControll._instance._listBuildPoint) 
            {
                if (Vector3.Distance(transform.position, _point.transform.position) < 0.5f)
                {
                    _colorPoint = Color.yellow;
                }
                else 
                {
                    _colorPoint = Color.green;
                }
            }
        }
    }

}
