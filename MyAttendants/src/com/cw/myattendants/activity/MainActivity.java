package com.cw.myattendants.activity;

import java.util.List;

import com.cw.myattendants.R;
import com.cw.myattendants.service.ListenGPSService;

import android.app.Activity;
import android.app.ActivityManager;
import android.app.ActivityManager.RunningServiceInfo;
import android.app.Application;
import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener
{

	Button startButton;
	Button stopButton;
Button exitButton;
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonStartSer);
		stopButton = (Button) findViewById(R.id.buttonStopSer);
		exitButton= (Button) findViewById(R.id.buttonExit);
		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
		exitButton.setOnClickListener(this);
	}

	@Override
	public void onClick(View v)
	{
		int vid = v.getId();
		switch (vid)
		{
			case R.id.buttonStartSer:
			{

				StartGPS();
			}
				break;
			case R.id.buttonStopSer:
			{
				
				StopGPS();
			}
				break;
			case R.id.buttonExit:
			{
				finish();

			}
				break;
		}

	}

	///[ GPS
	
	
	
	void StartGPS()
	{
		if (!CheckServiceIsRuning(ListenGPSService.class))
				{
					Intent gpsIntent = new Intent(this, ListenGPSService.class);

					ComponentName componentName = startService(gpsIntent);
					
					Toast.makeText(this, "服务启动", Toast.LENGTH_SHORT).show();
				} else
				{
					Toast.makeText(this, "服务重复启动", Toast.LENGTH_SHORT).show();
				}
	}
	
	void StopGPS()
	{
		Intent gpsIntent = new Intent(this, ListenGPSService.class);
				stopService(gpsIntent);
	}
	
	///]
	<T> // 检查服务是否正在运行
	boolean CheckServiceIsRuning(Class<T> classT)
	{
		ActivityManager activityManager = (ActivityManager) getSystemService(ACTIVITY_SERVICE);
		List<RunningServiceInfo> runningServiceInfos = activityManager
				.getRunningServices(Integer.MAX_VALUE);
		if (runningServiceInfos != null)
		{
			for (RunningServiceInfo runningServiceInfo : runningServiceInfos)
			{
				if (runningServiceInfo.service.getClassName().equals(classT.getName()))
				{

					return true;
				}
			}

		}
		return false;
	}

}
