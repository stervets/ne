using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotConstructor : MonoBehaviour {
	public List<GameObject> chassisList;
	public List<GameObject> bodyList;
	public List<GameObject> leftShoulderList;
	public List<GameObject> rightShoulderList;
	public List<GameObject> gunList;
	//ENUM (посмотреть!)
	private int chassisIndex = 0;
	private int bodyIndex = 0;
	private int leftShoulderIndex = 0;
	private int rightShoulderIndex = 0;
	private int leftTopGunIndex = 0;
	private int leftBottomGunIndex = 0;
	private int rightTopGunIndex = 0;
	private int rightBottomGunIndex = 0;

	public bool leftBottomGunAvailable = false;
	public bool rightBottomGunAvailable = false;

	private GameObject _chassis;
	private GameObject _body;
	private GameObject _leftShoulder;
	private GameObject _rightShoulder;
	private GameObject _leftTopGun;
	private GameObject _leftBottomGun;
	private GameObject _rightTopGun;
	private GameObject _rightBottomGun;

	public int chassis{
		set{
			SetChassis(value);
		}

		get{
			return chassisIndex;
		}
	}

	public int body{
		set{
			SetBody(value);
		}
		
		get{
			return bodyIndex;
		}
	}

	public int leftShoulder{
		set{
			SetLeftShoulder(value);
		}
		
		get{
			return leftShoulderIndex;
		}
	}

	public int rightShoulder{
		set{
			SetRightShoulder(value);
		}
		
		get{
			return rightShoulderIndex;
		}
	}

	public int leftTopGun{
		set{
			SetLeftTopGun(value);
		}
		
		get{
			return leftTopGunIndex;
		}
	}

	public int leftBottomGun{
		set{
			SetLeftBottomGun(value);
		}
		
		get{
			return leftBottomGunIndex;
		}
	}

	public int rightTopGun{
		set{
			SetRightTopGun(value);
		}
		
		get{
			return rightTopGunIndex;
		}
	}

	public int rightBottomGun{
		set{
			SetRightBottomGun(value);
		}
		
		get{
			return rightBottomGunIndex;
		}
	}

	private Transform chassisConnector;
	private Transform bodyConnector;
	private Transform leftShoulderConnector;
	private Transform rightShoulderConnector;
	private Transform leftTopGunConnector;
	private Transform leftBottomGunConnector;
	private Transform rightTopGunConnector;
	private Transform rightBottomGunConnector;


	private Transform RotatorH;
	private Transform RotatorV;

	private Quaternion targetH = Quaternion.identity;
	private Quaternion targetV = Quaternion.identity;
	private bool ready = false;

	void SetChassis(int index){
		if (_chassis!=null){
			Destroy(_chassis);
		}
		_chassis = Instantiate(chassisList[chassisIndex = index], chassisConnector.position, Quaternion.identity) as GameObject;
		_chassis.transform.parent = chassisConnector;
		RotatorH = bodyConnector = _chassis.transform.Find("base/connector");
		if (_body){
			body = bodyIndex;
		}
	}


	void SetBody(int index){
		if (_body!=null){
			Destroy(_body);
		}
		_body = Instantiate(bodyList[bodyIndex = index], bodyConnector.position, RotatorH.rotation) as GameObject;
		_body.transform.parent = bodyConnector;
		leftShoulderConnector = _body.transform.Find("base/rotor/left/connector");
		rightShoulderConnector = _body.transform.Find("base/rotor/right/connector");
		RotatorV = _body.transform.Find("base/rotor").transform;


			if (_leftShoulder!=null){
				leftShoulder = leftShoulderIndex;
			}

			
			if (_rightShoulder!=null){
				rightShoulder = rightShoulderIndex;
			}

	}


	void SetLeftShoulder(int index){
		if (_leftShoulder!=null){
			Destroy(_leftShoulder);
		}
		_leftShoulder = Instantiate(leftShoulderList[leftShoulderIndex = index], leftShoulderConnector.position, Quaternion.identity) as GameObject;
		_leftShoulder.transform.parent = leftShoulderConnector;
		_leftShoulder.transform.localPosition = Vector3.zero;
		_leftShoulder.transform.localRotation = Quaternion.identity;

		leftTopGunConnector = _leftShoulder.transform.Find("base/connector1");
		leftBottomGunConnector = _leftShoulder.transform.Find("base/connector2");

		if (_leftTopGun){
			leftTopGun = leftTopGunIndex;
		}

		leftBottomGunAvailable = !!leftBottomGunConnector;

		if (_leftBottomGun && !leftBottomGunAvailable){
			Destroy(_leftBottomGun);
			_leftBottomGun = null;
		}

		if (leftBottomGunAvailable){
			leftBottomGun = leftBottomGunIndex;
		}
	}

	void SetLeftTopGun(int index){
		if (_leftTopGun!=null){
			Destroy(_leftTopGun);
		}
		_leftTopGun = Instantiate(gunList[leftTopGunIndex = index], leftTopGunConnector.position, Quaternion.identity) as GameObject;
		_leftTopGun.transform.parent = leftTopGunConnector;
		_leftTopGun.transform.localPosition = Vector3.zero;
		_leftTopGun.transform.localRotation = Quaternion.identity;
	}

	void SetLeftBottomGun(int index){
		if (_leftBottomGun!=null){
			Destroy(_leftBottomGun);
		}
		_leftBottomGun = Instantiate(gunList[leftBottomGunIndex = index], leftBottomGunConnector.position, Quaternion.identity) as GameObject;
		_leftBottomGun.transform.parent = leftBottomGunConnector;
		_leftBottomGun.transform.localPosition = Vector3.zero;
		_leftBottomGun.transform.localRotation = Quaternion.identity;
	}


	void SetRightShoulder(int index){
		if (_rightShoulder!=null){
			Destroy(_rightShoulder);
		}
		_rightShoulder = Instantiate(rightShoulderList[rightShoulderIndex = index], rightShoulderConnector.position, Quaternion.identity) as GameObject;
		_rightShoulder.transform.parent = rightShoulderConnector;
		_rightShoulder.transform.localPosition = Vector3.zero;
		_rightShoulder.transform.localRotation = Quaternion.identity;
		
		rightTopGunConnector = _rightShoulder.transform.Find("base/connector1");
		rightBottomGunConnector = _rightShoulder.transform.Find("base/connector2");
		
		if (_rightTopGun){
			rightTopGun = rightTopGunIndex;
		}

		rightBottomGunAvailable = !!rightBottomGunConnector;

		if (_rightBottomGun && !rightBottomGunAvailable){
			Destroy(_rightBottomGun);
			_rightBottomGun = null;
		}
		
		if (rightBottomGunAvailable){
			rightBottomGun = rightBottomGunIndex;
		}
	}
	
	void SetRightTopGun(int index){
		if (_rightTopGun!=null){
			Destroy(_rightTopGun);
		}
		_rightTopGun = Instantiate(gunList[rightTopGunIndex = index], rightTopGunConnector.position, Quaternion.identity) as GameObject;
		_rightTopGun.transform.parent = rightTopGunConnector;
		_rightTopGun.transform.localPosition = Vector3.zero;
		_rightTopGun.transform.localRotation = Quaternion.identity;
	}
	
	void SetRightBottomGun(int index){
		if (_rightBottomGun!=null){
			Destroy(_rightBottomGun);
		}
		_rightBottomGun = Instantiate(gunList[rightBottomGunIndex = index], rightBottomGunConnector.position, Quaternion.identity) as GameObject;
		_rightBottomGun.transform.parent = rightBottomGunConnector;
		_rightBottomGun.transform.localPosition = Vector3.zero;
		_rightBottomGun.transform.localRotation = Quaternion.identity;
	}

	void assembleBot(){
		chassis = 0; //SetChassis(0)
		body = 0; 
		leftShoulder = 0;
		rightShoulder = 0;
		leftTopGun = 0;
		rightTopGun = 0;
		ready = true;
	}

	// Use this for initialization
	void Start () {
		Resource.BotPart.TryGetValue("chassis", out chassisList);
		Resource.BotPart.TryGetValue("body", out bodyList);
		Resource.BotPart.TryGetValue("shoulder/left", out leftShoulderList);
		Resource.BotPart.TryGetValue("shoulder/right", out rightShoulderList);
		Resource.BotPart.TryGetValue("gun", out gunList);
		chassisConnector = this.transform;
		assembleBot();
	}

	void FixedUpdate() {
		if (ready){

			RotatorH.localRotation = Quaternion.Lerp(RotatorH.localRotation, targetH, 0.01f);
			RotatorV.localRotation = Quaternion.Lerp(RotatorV.localRotation, targetV, 0.01f);

			if (Quaternion.Angle(RotatorH.localRotation, targetH)<0.4f){
				targetH = Quaternion.AngleAxis(Random.Range(-60, 60), Vector3.up);
			}


			if (Quaternion.Angle(RotatorV.localRotation, targetV)<0.4f){
				targetV = Quaternion.AngleAxis(Random.Range(-20, 20), Vector3.left);
			}

		}
	}
}
