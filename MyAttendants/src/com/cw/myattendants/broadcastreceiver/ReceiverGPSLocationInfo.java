package com.cw.myattendants.broadcastreceiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Handler;
import android.os.Message;

public class ReceiverGPSLocationInfo extends BroadcastReceiver
{

	Handler uiHandler;
	
	//传入一个句柄
	public ReceiverGPSLocationInfo(Handler uIHandler)
	{
		uiHandler = uIHandler;
	}

	@Override
	public void onReceive(Context context, Intent intent)
	{
		// TODO Auto-generated method stub
		if (uiHandler != null)
		{
			Message msg = uiHandler.obtainMessage();

			msg.setData(intent.getBundleExtra("gpsbundle"));
			
			uiHandler.sendMessage(msg);
		}
	}

}
