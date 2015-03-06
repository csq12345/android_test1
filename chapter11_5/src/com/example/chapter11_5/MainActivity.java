package com.example.chapter11_5;

import com.example.chapter11_4.IStockService;
import com.example.chapter11_5.R.id;

import android.app.Activity;
import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener
{

	String tag = "call main";
	Button bindButton;
	Button unbindButton;
	Button callButton;

	IStockService stockService;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		bindButton = (Button) findViewById(R.id.buttonBind);
		unbindButton = (Button) findViewById(R.id.buttonUnBind);
		callButton = (Button) findViewById(R.id.buttonCall);

		bindButton.setOnClickListener(this);
		unbindButton.setOnClickListener(this);
		callButton.setOnClickListener(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings)
		{
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onClick(View v)
	{
		int vid = v.getId();

		switch (vid)
		{
			case id.buttonBind:
			{
				Intent intent = new Intent(IStockService.class.getName());
				bindService(intent, serviceConnection, BIND_AUTO_CREATE);

			}
				break;
			case id.buttonUnBind:
			{
				unbindService(serviceConnection);
			}
				break;
			case id.buttonCall:
			{
				CallRemoteService();
			}
				break;
			default:
				break;
		}

	}

	void CallRemoteService()
	{
		try
		{
			double val = stockService.getPrice("alfa");
			Toast.makeText(this, "value :" + val, Toast.LENGTH_SHORT).show();
			
		} catch (Exception ex)
		{
			Log.e(tag, ex.getMessage());
		}
	}

	ServiceConnection serviceConnection = new ServiceConnection()
	{

		@Override
		public void onServiceDisconnected(ComponentName name)
		{
			Log.d(tag, "onServiceDisconnected");
			stockService = null;
		}

		@Override
		public void onServiceConnected(ComponentName name, IBinder service)
		{
			Log.d(tag, "onServiceConnected");

			stockService = IStockService.Stub.asInterface(service);

		}
	};

}
