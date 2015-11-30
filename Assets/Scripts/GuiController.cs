using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {
	private BotConstructor bot;


	private int chassis = 0;
	private int body = 0;
	private int leftShoulder = 0;
	private int rightShoulder = 0;
	private int leftTopGun = 0;
	private int leftBottomGun = 0;
	private int rightTopGun = 0;
	private int rightBottomGun = 0;

	private Text chassisText;
	private Text bodyText;
	private Text leftShoulderText;
	private Text rightShoulderText;
	private Text leftTopGunText;
	private Text rightTopGunText;
	private Text leftBottomGunText;
	private Text rightBottomGunText;

	private Transform rightBottomGunGUI;
	private Transform leftBottomGunGUI;

	// Use this for initialization
	void Start () {
		bot = GameObject.Find("BotConstructor").GetComponent<BotConstructor>();
		rightBottomGunGUI = transform.Find("rightBottomGun");
		leftBottomGunGUI = transform.Find("leftBottomGun");

		chassisText = transform.Find("chassis/text").GetComponent<Text>();
		chassisText.text = chassis.ToString();

		bodyText = transform.Find("body/text").GetComponent<Text>();
		bodyText.text = body.ToString();

		leftShoulderText = transform.Find("leftShoulder/text").GetComponent<Text>();
		leftShoulderText.text = leftShoulder.ToString();

		rightShoulderText = transform.Find("rightShoulder/text").GetComponent<Text>();
		rightShoulderText.text = rightShoulder.ToString();

		leftTopGunText = transform.Find("leftTopGun/text").GetComponent<Text>();
		leftTopGunText.text = leftTopGun.ToString();

		rightTopGunText = transform.Find("rightTopGun/text").GetComponent<Text>();
		rightTopGunText.text = rightTopGun.ToString();

		leftBottomGunText = transform.Find("leftBottomGun/text").GetComponent<Text>();
		leftBottomGunText.text = leftBottomGun.ToString();
		
		rightBottomGunText = transform.Find("rightBottomGun/text").GetComponent<Text>();
		rightBottomGunText.text = rightBottomGun.ToString();

		leftBottomGunGUI.gameObject.SetActive(bot.leftBottomGunAvailable);
		rightBottomGunGUI.gameObject.SetActive(bot.rightBottomGunAvailable);
	}

	public void nextChassis(){
		if (++chassis>=bot.chassisList.Count){
			chassis = 0;
		}
		bot.chassis = chassis;
		chassisText.text = chassis.ToString();
	}

	public void nextBody(){
		if (++body>=bot.bodyList.Count){
			body = 0;
		}
		bot.body = body;
		bodyText.text = body.ToString();
	}

	public void nextLeftShoulder(){
		if (++leftShoulder>=bot.leftShoulderList.Count){
			leftShoulder = 0;
		}
		bot.leftShoulder = leftShoulder;
		leftShoulderText.text = leftShoulder.ToString();

		leftBottomGunGUI.gameObject.SetActive(bot.leftBottomGunAvailable);
	}


	public void nextRightShoulder(){
		if (++rightShoulder>=bot.rightShoulderList.Count){
			rightShoulder = 0;
		}
		bot.rightShoulder = rightShoulder;
		rightShoulderText.text = rightShoulder.ToString();
		rightBottomGunGUI.gameObject.SetActive(bot.rightBottomGunAvailable);
	}


	public void nextLeftTopGun(){
		if (++leftTopGun>=bot.gunList.Count){
			leftTopGun = 0;
		}
		bot.leftTopGun = leftTopGun;
		leftTopGunText.text = leftTopGun.ToString();
	}


	public void nextRightTopGun(){
		if (++rightTopGun>=bot.gunList.Count){
			rightTopGun = 0;
		}
		bot.rightTopGun = rightTopGun;
		rightTopGunText.text = rightTopGun.ToString();
	}


	public void nextLeftBottomGun(){
		if (++leftBottomGun>=bot.gunList.Count){
			leftBottomGun = 0;
		}
		bot.leftBottomGun = leftBottomGun;
		leftBottomGunText.text = leftBottomGun.ToString();
	}
	
	
	public void nextRightBottomGun(){
		if (++rightBottomGun>=bot.gunList.Count){
			rightBottomGun = 0;
		}
		bot.rightBottomGun = rightBottomGun;
		rightBottomGunText.text = rightBottomGun.ToString();
	}

}
