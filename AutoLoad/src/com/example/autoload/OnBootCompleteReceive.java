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
		Log.d(tag, "系统启动完成");
		Toast.makeText(context, "系统启动完成", Toast.LENGTH_SHORT).show();
		//开始启动服务
		Intent serviceIntent=new Intent(context, AutoLoadService.class);
		
		
		
		context.startService(serviceIntent);
		
	}

}
