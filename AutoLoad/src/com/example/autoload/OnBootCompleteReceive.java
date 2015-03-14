package com.example.autoload;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.widget.Toast;

public class OnBootCompleteReceive extends BroadcastReceiver {

	String tag="autoload";
	
	Context thisContext;
	
	@Override
	public void onReceive(Context context, Intent intent) {
		Log.d(tag, "系统启动完成");
		thisContext=context;
		Message msg = myHandler.obtainMessage();
		Bundle bundle = new Bundle();
		bundle.putString("info", "系统启动完成");
		msg.setData(bundle);
		myHandler.sendMessage(msg);
		
		//开始启动服务
		Intent serviceIntent=new Intent(context, AutoLoadService.class);
		
		
		
		context.startService(serviceIntent);
		
	}
	
	Handler myHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {
			Toast.makeText(thisContext,
					msg.getData().getString("info"), Toast.LENGTH_SHORT).show();
			super.handleMessage(msg);
		}

	};

}
