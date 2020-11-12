using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private ManC _man;

    private RaycastHit _hit;

    private void Start()
    {
    }

    private void Update()
    {
        if(_man == null)
        {
            var _gender = 0;
            var _proffesion = 0;
            _gender = Random.Range(0, 2);
            _proffesion = Random.Range(0, 5);
            string __name = null;
            Gender __gender = (Gender)_gender;
            __name = __gender == 0 ? Database._instance._namesManMale[Random.Range(0, 5)] : Database._instance._namesManFemale[Random.Range(0, 5)];

            _man = new ManC(__name, __gender, AgeStage.Young, (Profession)_proffesion);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
        
        if (Physics.Raycast(ray, out _hit, 100))
        {
            if (_hit.transform.gameObject == gameObject)
            {
                if (Input.GetMouseButton(0))
                {
                    UIPanelCharacterInfo._instance.SetParam(_man);
                }
            }
        }
    }
}
