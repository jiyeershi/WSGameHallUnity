package unity2android.wesai.com.communication;

import com.unity3d.player.UnityPlayer;
import com.wesai.games.joint.sdk.PayEntity;
import android.util.*;

public class Utils {
	
    public static void doQueryUserInfo() {
        Log.d("MyGame", "doQueryUserInfo 1");
        Hall2GameInterface.getBo().doQueryUserInfo();
        Log.d("MyGame", "doQueryUserInfo 2");
    }

    public static void doPay(String orderId, int cost, String desc, String extraInfo) {
        Log.d("MyGame", "doPay 1");
        Log.d("MyGame", "orderId: "+orderId + " cost: "+cost+" desc: "+desc+ " extraInfo: "+extraInfo);
        PayEntity pay = new PayEntity(orderId, cost);
        pay.setOrder_id(orderId);
        pay.setAmount(cost);
        pay.setDescription(desc);
        pay.setExtra_content(extraInfo);
        Hall2GameInterface.getBo().doPay(pay);
//        UnityPlayer.UnitySendMessage("Main Camera","androidMessage", "event:" + "123" + "data:" + orderId );
        Log.d("MyGame", "doPay 2");
    }
    
    public static void doShare(String title, String content, String iconUrl, String url) {
        Log.d("MyGame", "doShare 1");
        Log.d("MyGame", "title: "+title + " content: "+content+" iconUrl: "+iconUrl+ " url: "+url);
        Hall2GameInterface.getBo().doShareRichText(title, content, iconUrl, url);
//        UnityPlayer.UnitySendMessage("Main Camera","androidMessage", "event:" + "123" + "data:" + content );
        Log.d("MyGame", "doShare 2");
    }
        
    public static String getPushStr() {
        Log.d("MyGame", "getPushStr");
        return Hall2GameInterface.pushStr;
//        return "test getPushStr";
    }
    
    public static String getLocationStr() {
    	 Log.d("MyGame", "getLocationStr");
    	return Hall2GameInterface.locationStr;
//    	return "test getLocationStr";
    }
    
    public static String doQueryWesaiUid(){
        Log.d("MyGame", "doQueryWesaiUid");
        return Hall2GameInterface.getBo().doQueryWesaiUid();
    }

    public static String doQueryGameId(){
        Log.d("MyGame", "doQueryGameId");
        return Hall2GameInterface.getBo().doQueryGameId();
    }
    
    public static void doQuitGame(){
    	Log.d("MyGame", "doQuitGame");
    	android.os.Process.killProcess(android.os.Process.myPid());
    }
}