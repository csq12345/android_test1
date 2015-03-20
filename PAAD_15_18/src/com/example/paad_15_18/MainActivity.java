package com.example.paad_15_18;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener
{

	Button startButton;
	Button stopButton;
	Button stop1Button;
	Button playButton;
	Button stopPlayButton;
	
MyRecord myRecord;

MyTrack myTrack;
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonStart);
		stopButton = (Button) findViewById(R.id.buttonStop);
		stop1Button = (Button) findViewById(R.id.buttonStop1);
		playButton = (Button) findViewById(R.id.buttonPlay);
		stopPlayButton = (Button) findViewById(R.id.buttonStopPlay);
		
		
		startButton.setOnClickListener(this);
		stopButton.setOnClickListener(this);
		stop1Button.setOnClickListener(this);
		playButton.setOnClickListener(this);
		stopPlayButton.setOnClickListener(this);
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
				if(myRecord==null)
				{
					myRecord=new MyRecord();
				}
				myRecord.Start();
			}
				break;
			case R.id.buttonStop:
			{
				if(myRecord!=null)
				{
					myRecord.Stop();
				}
			}
				break;
			case R.id.buttonStop1:
			{
				if(myRecord!=null)
				{
					myRecord.Stop1();
				}
			}
				break;
			case R.id.buttonPlay:
			{
				if(myTrack==null)
				{
					myTrack=new MyTrack(this);
				}
				myTrack.Play();
			}
				break;
			case R.id.buttonStopPlay:
			{
				if(myTrack!=null)
				{
					myTrack.StopPlay();
				}
			}
				break;
			default:
				break;
		}

	}
}
