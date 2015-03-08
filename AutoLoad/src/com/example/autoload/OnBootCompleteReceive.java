package com.example.autoload;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

public class OnBootCompleteReceive extends BroadcastReceiver {

	String tag="autoload";
	@Override
	public void onReceive(Context context, Intent intent) {
		Log.d(tag, "ϵͳ�������");
		Toast.makeText(context, "ϵͳ�������", Toast.LENGTH_SHORT).show();
		//��ʼ��������
		Intent serviceIntent=new Intent(context, AutoLoadService.class);
		
		
		
		context.startService(serviceIntent);
		
	}

}
