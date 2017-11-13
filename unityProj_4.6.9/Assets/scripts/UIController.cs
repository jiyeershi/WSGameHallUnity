using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

	// Use this for initialization
    public GameObject go;
    private Text text;
    private Text curTextApi;
    private Text locationText;
    private string curApi = "";
    private string[] urlArr = new string[] {
        "http://game.test.api.wesai.com/intra/virtualMedal",
        "http://game-pre.api.wesai.com/intra/virtualMedal", 
        "http://game.api.wesai.com/intra/virtualMedal",        
    };
    private int index;
    void Start()
    {
        //string str = Application.dataPath;
        List<string> btnsName = new List<string>();
        btnsName.Add("BtnPay");
        btnsName.Add("BtnQuit");
        btnsName.Add("BtnQuary");
        btnsName.Add("BtnAdd");
        btnsName.Add("BtnChangeApi");
        btnsName.Add("BtnShare");
        btnsName.Add("BtnPush");
        btnsName.Add("BtnLocation");

        foreach (string btnName in btnsName)
        {
            GameObject btnObj = GameObject.Find(btnName);
            Button btn = btnObj.GetComponent<Button>();
            EventTriggerListener.Get(btn.gameObject).onClick = OnClick;
        }

        GameObject to = GameObject.Find("Text_msg");
        text = to.GetComponent<Text>();
        to = GameObject.Find("Text_api");
        curTextApi = to.GetComponent<Text>();
        this.index = 0;
        this.setCurEnv();
        to = GameObject.Find("Text_location");
        locationText = to.GetComponent<Text>();
    }
	
    private void setCurEnv(){
        this.curApi = this.urlArr[this.index];
        this.curTextApi.text = "当前环境："+ this.curApi;
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick(GameObject sender)
    {
        text.text = "";
        AndroidInterface ao = go.GetComponent<AndroidInterface>();
        switch (sender.name)
        {
            case "BtnPay":
                Debug.Log("Button BtnPay. ClickHandler.");
                System.DateTime now = System.DateTime.Now;
                int ms = now.Millisecond;
                ao.doPay(ms.ToString(), 10, "Untiy 购买测试", "");
                break;
            case "BtnQuit":
                Debug.Log("Button BtnQuit. ClickHandler.");
                ao.doQuitGame();
                break;
            case "BtnQuary":
                Debug.Log("Button BtnQuary. ClickHandler.");
                ao.doQueryUserInfo();
                break;
            case "BtnChangeApi":
                Debug.Log("Button BtnChangeApi. ClickHandler.");
                this.index = (++this.index) % 3;
                setCurEnv();
                break;
            case "BtnShare":
                Debug.Log("Button BtnShare. ClickHandler.");
                ao.doShare("Unity分享测试",
                    "这是一条测试信息",
                    "https://static.wesai.com/ticketv2-product_static/pc/img/v2/logov2.png?v=819c55576907f5d888b19dce8b33326d",
                    "https://www.wesai.com/");
                break;
            case "BtnPush":
                Debug.Log("Button BtnPush. ClickHandler.");
                string pushStr = ao.doGetPushStr();
                locationText.text = pushStr;
                break;
            case "BtnLocation":
                Debug.Log("Button BtnLocation. ClickHandler.");
                string location = ao.doGetLocationStr();
                locationText.text = location;
                break;
            case "BtnAdd":
                Debug.Log("Button BtnAdd. ClickHandler.");
                string uId = ao.doQueryWesaiUid();
                string gameId = ao.doQueryGameId();
                Debug.Log("url = " + this.curApi + " uid = " + uId + " gameId = "+ gameId);
                WWWForm form = new WWWForm();
                form.AddField("user_id", uId);
                form.AddField("game_id", gameId);
                form.AddField("medal_value", 1);
                StartCoroutine(SendPost(this.curApi, form));  
                break;
        }
    }

    IEnumerator SendPost(string _url, WWWForm _wForm)
    {
        WWW postData = new WWW(_url, _wForm);
        yield return postData;
        if (postData.error != null)
        {
            Debug.Log(postData.error);
            text.text = postData.error;
        }
        else
        {
            Debug.Log(postData.text);
            text.text = postData.text;
        }
    } 

    public void showMessage(string str){
        text.text = str;
    }
}
