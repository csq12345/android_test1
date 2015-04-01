package com.example.paad_16_6;

import java.io.IOException;
import java.util.Set;
import java.util.UUID;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener
{

	String tag = "main bluetooth";

	Button startButton;
	Button stopButton;
	Button getdeviceButton;

	BluetoothAdapter bluetoothAdapter;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonStart);
		stopButton = (Button) findViewById(R.id.buttonStop);
		getdeviceButton = (Button) findViewById(R.id.buttonGetDevices);

		
		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
		getdeviceButton.setOnClickListener(this);
		
		
		
		bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

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
			case R.id.buttonStart:
			{

			}
				break;
			case R.id.buttonStop:
			{

			}
				break;
			case R.id.buttonGetDevices:
			{
				Set<BluetoothDevice> devices = bluetoothAdapter
						.getBondedDevices();

				if (devices != null)
				{
					for (BluetoothDevice bluetoothDevice : devices)// 列出所有已绑定的设备
					{
						Log.d(tag, bluetoothDevice.getName() + " "
								+ bluetoothDevice.getAddress());
//						try
//						{
//							bluetoothDevice.createRfcommSocketToServiceRecord(UUID.fromString(""));
//						} catch (IOException e)
//						{
//							// TODO Auto-generated catch block
//							e.printStackTrace();
//						}
					}
				}

			}
				break;
			default:
				break;
		}

	}
}
