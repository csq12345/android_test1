package com.cw.myattendants.activity;

import java.util.List;

import com.cw.myattendants.R;
import com.cw.myattendants.broadcastreceiver.ReceiverGPSLocationInfo;
import com.cw.myattendants.service.ListenGPSService;

import android.app.Activity;
import android.app.ActivityManager;
import android.app.ActivityManager.RunningServiceInfo;
import android.app.Application;
import android.content.ComponentName;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.Handler;
import android.os.IBinder;
import android.os.Message;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener
{

	Button startButton;
	Button stopButton;
	Button exitButton;
	Button registerGpsButton;
	Button unregisterGpsButton;

	TextView latiduteTextView, longiduTextView, satalliteTextView,bundelTextView;

	//接受包计数
	int bunblecount=0;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonStartSer);
		stopButton = (Button) findViewById(R.id.buttonStopSer);
		exitButton = (Button) findViewById(R.id.buttonExit);

		registerGpsButton = (Button) findViewById(R.id.buttonRegisterGPS);
		unregisterGpsButton = (Button) findViewById(R.id.buttonUnRegisterGPS);

		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
		exitButton.setOnClickListener(this);

		registerGpsButton.setOnClickListener(this);
		unregisterGpsButton.setOnClickListener(this);

		longiduTextView = (TextView) findViewById(R.id.textViewLongitude);
		latiduteTextView = (TextView) findViewById(R.id.textViewLatidute);
		satalliteTextView = (TextView) findViewById(R.id.textViewSatellite);
		bundelTextView=(TextView)findViewById(R.id.textViewBundelCount);
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
			case R.id.buttonRegisterGPS:// 注册gps
			{
				Register();
			}
				break;
			case R.id.buttonUnRegisterGPS:// 注销gps
			{
				UnRegister();
			}
				break;
		}

	}

	// /[ GPS

	void StartGPS()
	{
		if (!CheckServiceIsRuning(ListenGPSService.class))
		{
			Intent gpsIntent = new Intent(this, ListenGPSService.class);

			startService(gpsIntent);

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

	String intentTag = "com.cw.myattendants.service.ListenGPSService";
	Handler gpsHandler;
	ReceiverGPSLocationInfo receiverGPSLocationInfo;

	void Register()
	{
		if (receiverGPSLocationInfo == null)
		{
			gpsHandler = new Handler(new Handler.Callback()
			{

				@Override
				public boolean handleMessage(Message msg)
				{
					// TODO Auto-generated method stub
					bunblecount++;
					Bundle bundle = msg.getData();

					double longitude = bundle.getDouble("Longitude");// 经度
					double latitude = bundle.getDouble("Latitude");// 纬度

					int count = bundle.getInt("SatelliteCount");

					longiduTextView.setText(String.valueOf(longitude));
					latiduteTextView.setText(String.valueOf(latitude));
					satalliteTextView.setText(String.valueOf(count));
					bundelTextView.setText(String.valueOf(bunblecount));
					return true;
				}
			});

			IntentFilter intentFilter = new IntentFilter(intentTag);

			receiverGPSLocationInfo = new ReceiverGPSLocationInfo(gpsHandler);

			registerReceiver(receiverGPSLocationInfo, intentFilter);

		}
		else {
			Toast.makeText(this, "重复注册",1).show();
		}
	}

	void UnRegister()
	{
		if (receiverGPSLocationInfo != null)
		{
			unregisterReceiver(receiverGPSLocationInfo);
			receiverGPSLocationInfo=null;
		}

	}

	// /]

	// 检查服务是否正在运行
	<T> boolean CheckServiceIsRuning(Class<T> classT)
	{
		ActivityManager activityManager = (ActivityManager) getSystemService(ACTIVITY_SERVICE);
		List<RunningServiceInfo> runningServiceInfos = activityManager
				.getRunningServices(Integer.MAX_VALUE);
		if (runningServiceInfos != null)
		{
			for (RunningServiceInfo runningServiceInfo : runningServiceInfos)
			{
				if (runningServiceInfo.service.getClassName().equals(
						classT.getName()))
				{

					return true;
				}
			}

		}
		return false;
	}

}
