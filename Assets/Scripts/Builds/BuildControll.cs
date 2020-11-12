using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BuildStage 
{
	Noone = 0,
	Location = 1
}

public enum MouseCanDrag
{
	Can = 0,
	DCan = 1
}

public enum BuildMoveType 
{
	Rotate = 0,
	RotateAngle = 1,
	MoveAxis = 2,
	MovePoint = 3
}

public enum CameraMode 
{
	Build = 0,
	Free = 1
}

public class BuildControll : MonoBehaviour
{

	[SerializeField] private GameObject _UIStorage;

    #region varibles
	[SerializeField] private Rigidbody _cameraRigidbody = null;
	[SerializeField] private float _speedCamera = 0;
	[SerializeField] private Vector3Int _positionBuild;

	[Space(10)]
	[Header("New build settings")]
	[SerializeField] private GameObject _buildTemplate = null;
	[SerializeField] private GameObject _template = null;
	[SerializeField] private Mesh _meshTemplate = null;
	[SerializeField] private BoxCollider _colliderTemplate = null;
	[SerializeField] private Mesh _constructionMesh = null;

	[Space(10)]
	[Header("Build mesh")]
	[SerializeField] private Mesh[] _houseSmallMesh = null;
	[SerializeField] private Mesh[] _houseNormalMesh = null;
	[SerializeField] private Mesh[] _houseBigMesh = null;

	[Space(10)]
	[Header("Build colliders")]
	[SerializeField] private BoxCollider[] _houseSmallCollider = null;	
	[SerializeField] private BoxCollider[] _houseNormalCollider = null;
	[SerializeField] private BoxCollider[] _houseBigCollider = null;
	
	public static BuildControll _instance = null;

	[SerializeField] private BuildC _buildProject;

	[Space(10)]
	[Header("Build materials")]
	[SerializeField] private Material _buildMaterialCan = null;
	[SerializeField] private Material _buildMaterialDCan = null;
	[SerializeField] private Material _defultMaterial = null;

	[SerializeField] private RaycastHit hit;

	[SerializeField] private BuildStage _buildStage;
	[SerializeField] private BuildMoveType _buildMoveType;
	[SerializeField] private CameraMode _cameraMode;
	public MouseCanDrag _mouseCanDrag;


	private float _angleYCamera;
	private float _angleYBuild;
	private float _cameraZoom = 60;

	public List<BuildMovePoint> _listBuildPoint;

    #endregion

    private void Start()
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

	public void SetBuildProject(BuildC __buildPrject) 
	{
		_buildProject = __buildPrject;
		if (_buildProject != null)
			Debug.Log("Build Success");
		else
			Debug.Log("Build Fail");
		_buildStage = BuildStage.Location;
	}
	private void OnGUI()
	{
		float fps = 0;
		fps = 1.0f / Time.deltaTime;
		GUILayout.Label("FPS: " + (int)fps + "  " + "Camera mode:" + _cameraMode.ToString());
	}
	private void Update()
    {
		#region CameraMove

		_cameraZoom = Mathf.Clamp(_cameraZoom, 40, 80);
		//Camera.main.fieldOfView = _cameraZoom;
		if (Input. GetKey(KeyCode.W))
		{
			_cameraRigidbody.velocity += _cameraRigidbody.transform.forward * _speedCamera;
		}
		if (Input.GetKey(KeyCode.S))
		{
			_cameraRigidbody.velocity += _cameraRigidbody.transform.forward * -_speedCamera;
		}
		if (Input.GetKey(KeyCode.D))
		{
			_cameraRigidbody.velocity += _cameraRigidbody.transform.right * _speedCamera;
		}
		if (Input.GetKey(KeyCode.A))
		{
			_cameraRigidbody.velocity += _cameraRigidbody.transform.right * -_speedCamera;
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			_cameraMode = _cameraMode == CameraMode.Build ? _cameraMode = CameraMode.Free : _cameraMode = CameraMode.Build;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
		{
			_cameraZoom -= 1;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			_cameraZoom += 1;
		}
		if (_cameraMode == CameraMode.Free) 
		{
			if (Input.GetMouseButton(1)) 
			{
				TestCameraRotate._cameraRotate.MoveCamera();
			}
		}
		#endregion
		#region BuildMove
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (_buildStage == BuildStage.Location && _mouseCanDrag == MouseCanDrag.Can)
		{
			if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("BuildPlace")))
			{
				if (!_template)
				{
					_template = Instantiate(_buildTemplate, transform.position, Quaternion.identity);
					_template.GetComponentInChildren<MeshFilter>().mesh = _meshTemplate;
					_template.AddComponent<PlaceCheck>();
					_template.transform.rotation = Quaternion.Euler(0, 0, 0);
					_angleYBuild = 0;
					SetTemplateColliderSettings();
					_template.GetComponentInChildren<MeshRenderer>().material = _buildMaterialCan;
				}
				Debug.DrawRay(Camera.main.transform.position, ray.direction * 100);
				Vector3 _worldPosition = hit.point;
				int x = Mathf.RoundToInt(_worldPosition.x);
				int z = Mathf.RoundToInt(_worldPosition.z);
				_template.transform.position = new Vector3(x, 0, z);
			}
			BuildPlaceControll();
		}
		if (_template) 
		{
			if (Input.GetMouseButton(0) && _template)
			{
				if (_template.GetComponent<PlaceCheck>().IsPlaceFree())
				{
					_buildStage = BuildStage.Noone;
					_template.GetComponentInChildren<MeshRenderer>().material = _defultMaterial;
					_template.AddComponent<Build>();
					_template.GetComponent<Build>().SetBuild(_buildProject);
					_template.GetComponent<Build>().SetBuildState(BuildState.Carryng);
					_template.GetComponent<Build>().GetUIStorage(_UIStorage);
					Destroy(_template.GetComponent<PlaceCheck>());
					_template = null;
				}

			}
		}
		#endregion
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_UIStorage.SetActive(false);
		}
	}

    private void BuildPlaceControll() 
	{

		if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
			_buildMoveType = BuildMoveType.RotateAngle;
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			_buildMoveType = BuildMoveType.MovePoint;


		switch (_buildMoveType) 
		{
			case BuildMoveType.RotateAngle:
				if (Input.GetKeyDown(KeyCode.E))
				{
					_angleYBuild -= 90;
					_template.transform.rotation = Quaternion.Euler(_template.transform.rotation.x, _angleYBuild, _template.transform.rotation.z);
				}
				if (Input.GetKeyDown(KeyCode.Q))
				{
					_angleYBuild += 90;
					_template.transform.rotation = Quaternion.Euler(_template.transform.rotation.x, _angleYBuild, _template.transform.rotation.z);
				}
				break;
			case BuildMoveType.Rotate:
				if (Input.GetKey(KeyCode.Q))
				{
					_template.transform.Rotate(0, 100 * Time.deltaTime, 0);
				}
				if (Input.GetKey(KeyCode.E))
				{
					_template.transform.Rotate(0, -100 * Time.deltaTime, 0);
				}
				break;
		}
	}

	public void SetMeshTemplate(Mesh __mesh) 
	{
		_meshTemplate = __mesh;
	}

	public void SetColliderTemplate(BoxCollider __collider) 
	{
		_colliderTemplate = __collider;
	}

	public Mesh GetMeshHouse(BuildSize __size, int __id) 
	{
		switch (__size) 
		{
			case BuildSize.Small:
				return _houseSmallMesh[__id];
			case BuildSize.Normal:
				return _houseNormalMesh[__id];
			case BuildSize.Big:
				return _houseBigMesh[__id];
		}
		return null;
	}

	public BoxCollider GetColliderHouse(BuildSize __size, int __id) 
	{
		switch (__size) 
		{
			case BuildSize.Small:
				return _houseSmallCollider[__id];
			case BuildSize.Normal:
				return _houseNormalCollider[__id];
			case BuildSize.Big:
				return _houseBigCollider[__id];
		}		
		return null;
	} 

	public Material GetMaterialPlaceFree() 
	{
		return _buildMaterialCan;
	}

	public Material GetMaterialPlaceDFree()
	{
		return _buildMaterialDCan;
	}

	public GameObject GetTemplate() 
	{
		if (_template)
			return _template;
		return null;
	}

	public void SetTemplateColliderSettings() 
	{
		_template.AddComponent<BoxCollider>();
		_template.GetComponent<BoxCollider>().isTrigger = true;
		_template.GetComponent<BoxCollider>().size = _colliderTemplate.size;
		_template.GetComponent<BoxCollider>().center = _colliderTemplate.center;
		_template.GetComponent<NavMeshObstacle>().size = _colliderTemplate.size;
		_template.GetComponent<NavMeshObstacle>().center = _colliderTemplate.center;
	}
}
