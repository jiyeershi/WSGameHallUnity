using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AndroidInterface : MonoBehaviour {

	// Use this for initialization
    private AndroidJavaObject jo;
    public GameObject go;

	void Start () {
        Debug.Log("Start AndridInterface");
	    jo = new AndroidJavaObject("unity2android.wesai.com.communication.Utils");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void doPay(string orderId, int cost, string desc, string extraInfo) {

        jo.CallStatic("doPay", orderId, cost, desc, extraInfo);
    }

    public void doQueryUserInfo()
    {
        jo.CallStatic("doQueryUserInfo");
    }

    public string doQueryWesaiUid()
    {
        return jo.CallStatic<string>("doQueryWesaiUid");
        //return "";
    }

    public string doQueryGameId()
    {
        return jo.CallStatic<string>("doQueryGameId");
        //return "";
    }

    public void doShare(string title, string content, string iconUrl, string url)
    {
        jo.CallStatic("doShare", title, content, iconUrl, url);
    }

    public string doGetPushStr()
    {
        return jo.CallStatic<string>("getPushStr");
    }

    public string doGetLocationStr()
    {
        return jo.CallStatic<string>("getLocationStr");
    }


    public void doQuitGame()
    {
        jo.CallStatic("doQuitGame");
    }

    void androidMessage(string message){
        Debug.Log("androidMessage: "+ message);
        Debug.Log("androidMessage 1");
        UIController ctl = go.GetComponent<UIController>();
        ctl.showMessage(message);
        Debug.Log("androidMessage 2");
    }

}
