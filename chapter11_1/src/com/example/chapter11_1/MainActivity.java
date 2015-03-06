package com.example.chapter11_1;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener
{

	Button startButton;
	Button stopButton;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonOpen);
		stopButton = (Button) findViewById(R.id.buttonStop);
		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
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
		int bid = v.getId();
		if (bid == R.id.buttonOpen)
		{
			Log.d("dddd","open");
			startService(new Intent(this, MyLocalService.class));

		} else if (bid == R.id.buttonStop)
		{

			stopService(new Intent(this, MyLocalService.class));
		}

	}
}
