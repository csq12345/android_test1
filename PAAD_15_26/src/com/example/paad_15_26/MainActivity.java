package com.example.paad_15_26;

import android.app.Activity;
import android.hardware.Camera;
import android.hardware.Camera.Face;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Switch;

public class MainActivity extends Activity implements SurfaceHolder.Callback,
		OnClickListener
{

	String tag = "camera异常";

	Camera myCamera;
	Button button1;
	Button button2;
	Button button3;
	SurfaceView mySurfaceView;
	SurfaceHolder mySurfaceHolder;
int fi=0;
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		button1 = (Button) findViewById(R.id.button1);
		button2 = (Button) findViewById(R.id.button2);
		button3 = (Button) findViewById(R.id.button3);
		
		myCamera = Camera.open();
		
		mySurfaceView = (SurfaceView) findViewById(R.id.surfaceView1);
		mySurfaceHolder = mySurfaceView.getHolder();
		mySurfaceHolder.addCallback(this);
		mySurfaceHolder.setFixedSize(200, 150);
		
		button1.setOnClickListener(this);
		button2.setOnClickListener(this);
		button3.setOnClickListener(this);
		

		//设置预览回调 查看帧图像
		myCamera.setPreviewCallback(new Camera.PreviewCallback()
		{
			
			@Override
			public void onPreviewFrame(byte[] data, Camera camera)
			{
				// TODO Auto-generated method stub
				
			}
		});
		
		
		//设置人脸识别
		myCamera.setFaceDetectionListener(new Camera.FaceDetectionListener()
		{
			
			@Override
			public void onFaceDetection(Face[] faces, Camera camera)
			{
				// TODO Auto-generated method stub
				Log.d(tag, "检测到人脸"+faces.length);
			}
		});
		
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

	// /[ SurfaceHolderCallback

	@Override
	public void surfaceCreated(SurfaceHolder holder)
	{
		// TODO Auto-generated method stub
		try
		{
			myCamera.setPreviewDisplay(holder);
			myCamera.startPreview();
			myCamera.startFaceDetection();

		} catch (Exception ex)
		{
			// TODO: handle exception
			Log.d(tag, ex.getMessage());
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
		myCamera.stopPreview();
		myCamera.setPreviewCallback(null);
		myCamera.release();
	}

	// /]

	@Override
	public void onClick(View v)
	{
		// TODO Auto-generated method stub
		int vid = v.getId();
		switch (vid)
		{
			case R.id.button1:
				
				Init();
				break;
			case R.id.button2:
				
				int mc=myCamera.getParameters().getMaxNumDetectedFaces();
			Log.d(tag, "面部识别"+mc);
				break;
			case R.id.button3:			
				myCamera.stopPreview();
				myCamera.setPreviewCallback(null);
				myCamera.release();
				break;
			default:
				break;
		}
	}
	
	void Init()
	{
		try
		{	
			
			
		} catch (Exception ex)
		{
			Log.d(tag, ex.getMessage());
		}
		
	}
}
