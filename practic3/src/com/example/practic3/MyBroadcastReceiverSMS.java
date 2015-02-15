package com.example.practic3;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

public class MyBroadcastReceiverSMS extends BroadcastReceiver {

	@Override
	public void onReceive(Context context, Intent intent) {
		// TODO Auto-generated method stub
		try {
			Log.i("MyBroadcastReceiver", "接收到广播");

		System.out.print("接收到广播");
		Toast.makeText(context, "接收到广播", Toast.LENGTH_SHORT).show();

//		Intent openIntent = new Intent();
//		openIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);  
//		openIntent.setClassName("com.example.practic1",
//				"com.example.practic1.MainActivity");
//
//		context.startActivity(openIntent);
		} catch (Exception e) {
			// TODO: handle exception
			Log.i("MyBroadcastReceiver","onReceive异常");
		}
		

	}

}
