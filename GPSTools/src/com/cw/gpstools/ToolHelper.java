package com.cw.gpstools;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.IBinder;
import android.util.Log;

import com.cw.gpstools.WorkService.GPSService;

//������
public class ToolHelper {

	public boolean OpenGPSService(Context context) {

		Intent serIntent = new Intent();
		serIntent.setClass(context, GPSService.class);
		// ���֮ǰ�����Ƿ�����
		ServiceConnection serviceConnection = new ServiceConnection() {

			@Override
			public void onServiceDisconnected(ComponentName name) {
				// TODO Auto-generated method stub

			}

			@Override
			public void onServiceConnected(ComponentName name, IBinder service) {
				// TODO Auto-generated method stub
				Log.i("gps", "onServiceConnected");
			}
		};
		boolean b = context.bindService(serIntent, serviceConnection,
				context.BIND_ADJUST_WITH_ACTIVITY);

		if (b) {

		} else {
			// �����·���
			ComponentName componentName = context.startService(serIntent);
		}

		return true;
	}

}
