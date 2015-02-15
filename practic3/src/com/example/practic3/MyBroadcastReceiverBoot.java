package com.example.practic3;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

public class MyBroadcastReceiverBoot extends BroadcastReceiver {

	@Override
	public void onReceive(Context context, Intent intent) {
		// TODO Auto-generated method stub
		
		Toast.makeText(context, "Æô¶¯Íê³É", Toast.LENGTH_LONG).show();
		
		Intent openIntent = new Intent();
		openIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);  
		openIntent.setClassName("com.example.practic1",
				"com.example.practic1.MainActivity");

		context.startActivity(openIntent);	
	}

}
