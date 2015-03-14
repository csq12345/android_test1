package com.example.autoload;

import java.util.Random;

import android.R.integer;
import android.app.ActivityManager;
import android.app.Service;
import android.app.ActivityManager.RecentTaskInfo;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.IBinder;
import android.os.Message;
import android.os.MessageQueue;
import android.os.SystemClock;
import android.util.Log;
import android.widget.Toast;

public class AutoLoadService extends Service {

	String tag = "autoload";

	Runnable runnable;

	Thread t1;

	boolean isrun = false;

	int c = 0;

	@Override
	public IBinder onBind(Intent intent) {
		Log.d(tag, "onBind");
		return null;
	}

	@Override
	public void onCreate() {
		Log.d(tag, "onCreate");
		super.onCreate();
	}

	@Override
	public void onDestroy() {
		Log.d(tag, "onDestroy");

		isrun = false;

		super.onDestroy();
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		Log.d(tag, "onStartCommand");
		if (runnable == null) {
			runnable = GetRunnable();
		}
		if (t1 == null) {
			t1 = new Thread(runnable);
			t1.start();
			isrun = true;
		}

		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public boolean onUnbind(Intent intent) {
		Log.d(tag, "onUnbind");
		return super.onUnbind(intent);
	}

	// ��ȡҪִ�е�����
	Runnable GetRunnable() {
		Runnable myRunnable = new Runnable() {

			@Override
			public void run() {

				int randnum = new Random().nextInt(100);
				int c = 0;
				String info = "";
				ActivityManager activityManager = (ActivityManager) getSystemService(ACTIVITY_SERVICE);

				while (isrun) {
					// c++;
					Log.d(tag, "running " + randnum);

					// ��ȡ��ǰ��ʾ��activity
					ComponentName componentName = activityManager
							.getRunningTasks(1).get(0).topActivity;
					info = "pack:" + componentName.getPackageName() + " class:"
							+ componentName.getClassName();
					Log.d(tag, info);

					// �ж�
					if (componentName.getClassName().equals(
							"com.hiveview.domybox.activity.MainActivity")) {

						Intent activityIntent = new Intent();
						ComponentName shafacomponentName = new ComponentName(
								"com.shafa.launcher",
								"com.shafa.launcher.ShafaHomeAct");
						activityIntent.setComponent(shafacomponentName);
						activityIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

						if (getPackageManager().resolveActivity(activityIntent,
								0) == null) {

							// ������
							Message msg = myHandler.obtainMessage();
							Bundle bundle = new Bundle();
							bundle.putString("info", "δ�ҵ�ɳ������");
							msg.setData(bundle);
							myHandler.sendMessage(msg);
							isrun=false;
						} else {
							Message msg = myHandler.obtainMessage();
							Bundle bundle = new Bundle();
							bundle.putString("info", "ֹͣ��ʾ ��������");
							msg.setData(bundle);
							myHandler.sendMessage(msg);
							startActivity(activityIntent);
						}

					} else {
						// Message msg = myHandler.obtainMessage();
						// Bundle bundle = new Bundle();
						// // bundle.putString("info", "��ǰ��ʾ domybox.activity");
						// bundle.putString("info",
						// componentName.getClassName());
						// msg.setData(bundle);
						// myHandler.sendMessage(msg);
					}

					SystemClock.sleep(1000);
				}
			}
		};

		return myRunnable;
	}

	Handler myHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {
			Toast.makeText(getApplicationContext(),
					msg.getData().getString("info"), Toast.LENGTH_SHORT).show();
			super.handleMessage(msg);
		}

	};

}
