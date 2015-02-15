package com.cw.gpstools;

import com.cw.gpstools.WorkService.GPSService;

import android.app.Activity;
import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.view.View;
import android.widget.Button;

public class MainActivity extends Activity {

	Button openButton;
	Button closeButton;
	Button exitButton;

	GPSService gpsService;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		openButton = (Button) findViewById(R.id.buttonOpenSer);
		closeButton = (Button) findViewById(R.id.buttonCloseSer);
		exitButton = (Button) findViewById(R.id.buttonExit);

		// /[打开gps服务
		openButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent serIntent = new Intent();
				serIntent.setClass(MainActivity.this, GPSService.class);
				// 检查之前服务是否运行
				ServiceConnection serviceConnection = new ServiceConnection() {

					@Override
					public void onServiceDisconnected(ComponentName name) {
						// TODO Auto-generated method stub

					}

					@Override
					public void onServiceConnected(ComponentName name,
							IBinder service) {
						// TODO Auto-generated method stub
						Log.i("gps", "onServiceConnected");
					}
				};
				boolean b = bindService(serIntent, serviceConnection,
						BIND_ADJUST_WITH_ACTIVITY);

				if (b) {
					

				} else {
					// 创建新服务

					ComponentName componentName = startService(serIntent);
				}

			}
		});

		// /]

		// /[关闭gps服务
		closeButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

			}
		});
		// /]

		// /[退出
		exitButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				MainActivity.this.finish();
			}
		});
		// /]
	}

}
