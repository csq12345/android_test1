package com.example.autoload;

import java.net.URI;

import android.R.integer;
import android.app.Activity;
import android.content.ComponentName;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener {

	String tag="autoload";
	
	Button startButton;
	Button stopButton;
	
	Button bindButton;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		
		startButton=(Button) findViewById(R.id.buttonStart);
		
		stopButton=(Button) findViewById(R.id.buttonStop);
		bindButton=(Button) findViewById(R.id.buttonBind);
		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
		bindButton.setOnClickListener(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onClick(View v) {
		int vid = v.getId();

		switch (vid) {
		case R.id.buttonStart: {
			Log.d(tag, "点击开始服务");
			Toast.makeText(this, "点击开始服务", Toast.LENGTH_SHORT).show();
			Intent serviceIntent=new Intent(this, AutoLoadService.class);
			startService(serviceIntent);
		}
			break;
		case R.id.buttonStop: {
			Log.d(tag, "点击停止服务");
			Toast.makeText(this, "点击停止服务", Toast.LENGTH_SHORT).show();
			Intent serviceIntent=new Intent(this, AutoLoadService.class);
			stopService(serviceIntent);
		}
			break;
			
		case R.id.buttonBind: {
			Log.d(tag, "点击绑定服务");
			Toast.makeText(this, "点击绑定服务", Toast.LENGTH_SHORT).show();
			
			Intent activityIntent = new Intent(); 
			ComponentName componentName = new ComponentName("com.shafa.launcher","com.shafa.launcher.ShafaHomeAct");//这个没问题 
			activityIntent.setComponent(componentName);
			activityIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			startActivity(activityIntent);
		}
			break;
		}

	}

}
