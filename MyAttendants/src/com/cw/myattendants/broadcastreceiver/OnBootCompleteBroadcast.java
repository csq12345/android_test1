package com.cw.myattendants.broadcastreceiver;


import com.cw.myattendants.service.ListenGPSService;


import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

public class OnBootCompleteBroadcast extends BroadcastReceiver
{

	String tag="MyAttendant";
	@Override
	public void onReceive(Context context, Intent intent)
	{
		//Æô¶¯gps¼àÌý	
		Intent gpsIntent=new Intent(context,ListenGPSService.class);	
		context.startService(gpsIntent);
		Log.d(tag, "MyAttendantsÆô¶¯");
	}

}
