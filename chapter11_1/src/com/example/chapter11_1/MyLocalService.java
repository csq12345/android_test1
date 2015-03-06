package com.example.chapter11_1;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.os.SystemClock;
import android.util.Log;

public class MyLocalService extends Service
{

	String TAG = "MyLocalService";
	int NOTIFICATION_ID = 1;
	boolean isRunning;

	NotificationManager notificationManager;

	@Override
	public IBinder onBind(Intent intent)
	{
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void onCreate()
	{

		super.onCreate();

		Log.d(TAG, "onCreate()");

		notificationManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{

		Log.d(TAG, "onStartCommand()");

		Displaynotification("Service onStartCommand");
		isRunning = true;

		Thread serviceThread = new Thread(new Runnable()
		{

			@Override
			public void run()
			{
				while (isRunning)
				{
					Log.d(TAG, "serviceThread Thread execute");

					SystemClock.sleep(10 * 1000);
				}

			}
		});

		serviceThread.start();

		
		
		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public void onDestroy()
	{

		Displaynotification("Service ondestroy");
		isRunning = false;
		Log.d(TAG, "onDestroy()");

		super.onDestroy();
	}

	@Override
	public boolean onUnbind(Intent intent)
	{
		// TODO Auto-generated method stub
		return super.onUnbind(intent);
	}

	@Override
	public void onRebind(Intent intent)
	{
		// TODO Auto-generated method stub
		super.onRebind(intent);
	}

	void Displaynotification(String message)
	{

		Notification notification = new Notification();
		notification.icon = R.drawable.ic_launcher;
		notification.when = System.currentTimeMillis();
		notification.tickerText = message;

		PendingIntent contentIntent = PendingIntent.getActivities(this, 0,
				new Intent[]
				{ new Intent(this, MainActivity.class) }, 0);
		notification.setLatestEventInfo(this, "Background Service", message,
				contentIntent);
		notificationManager.notify(NOTIFICATION_ID++, notification);
	}

}
