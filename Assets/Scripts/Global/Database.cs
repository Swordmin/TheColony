using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

	public string[] _namesManMale = new string[5] { "Max", "Den", "Van", "Lexa", "Jora" };
	public string[] _namesManFemale = new string[5] { "Amelia", "Nika", "Olga", "Anna", "Dr.F" };

	public static Database _instance = null;

	private GameObject[] _buildProcessBegin;
	private GameObject[] _house;


	void Start()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance == this)
		{
			Destroy(gameObject);
		}
	}
}
