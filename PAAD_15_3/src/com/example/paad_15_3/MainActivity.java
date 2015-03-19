package com.example.paad_15_3;

import java.io.File;

import android.app.Activity;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.provider.MediaStore.Audio.Media;
import android.provider.MediaStore.Files;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener,
		SurfaceHolder.Callback
{

	Button startButton;
	Button stopButton;

	String tag = "surfaceviewVideoview";
	MediaPlayer mediaPlayer;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startButton = (Button) findViewById(R.id.buttonStart);
		stopButton = (Button) findViewById(R.id.buttonStop);

		startButton.setOnClickListener(this);
		stopButton .setOnClickListener(this);

		
		mediaPlayer = new MediaPlayer();

		SurfaceView surfaceView = (SurfaceView) findViewById(R.id.surfaceView1);
		surfaceView.setKeepScreenOn(true);

		SurfaceHolder surfaceHolder = surfaceView.getHolder();
		surfaceHolder.addCallback(this);
		surfaceHolder.setType(SurfaceHolder.SURFACE_TYPE_PUSH_BUFFERS);
		surfaceHolder.setFixedSize(100, 100);

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
				mediaPlayer.start();
			}
				break;
			case R.id.buttonStop:
			{
				mediaPlayer.pause();
			}
				break;
		}

	}

	// /[ surfaceholder.callback

	@Override
	public void surfaceCreated(SurfaceHolder holder)
	{
		// TODO Auto-generated method stub
		try
		{
			mediaPlayer.setDisplay(holder);
			

			
			mediaPlayer.setDataSource("/sdcard/VID_20150318_165128.mp4");
			mediaPlayer.prepare();

		} catch (Exception ex)
		{
			Log.e(tag, "surfaceCreated“Ï≥£", ex);
		}
	}

	@Override
	public void surfaceChanged(SurfaceHolder holder, int format, int width,
			int height)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void surfaceDestroyed(SurfaceHolder holder)
	{
		// TODO Auto-generated method stub
mediaPlayer.release();;
	}

	// /]
}
