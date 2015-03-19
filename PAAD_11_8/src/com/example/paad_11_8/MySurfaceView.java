package com.example.paad_11_8;

import android.R.bool;
import android.R.integer;
import android.content.Context;
import android.graphics.Canvas;
import android.view.SurfaceHolder;
import android.view.SurfaceView;

public class MySurfaceView extends SurfaceView implements
		SurfaceHolder.Callback
{

	SurfaceHolder holder;
	MySurfaceViewThread mySurfaceViewThread;
	boolean hasSurface;

	public MySurfaceView(Context context)
	{
		super(context);
		// TODO Auto-generated constructor stub
		Init();
	}

	@Override
	public void surfaceCreated(SurfaceHolder holder)
	{
		hasSurface=true;
		
		if(mySurfaceViewThread!=null)
		{
			mySurfaceViewThread.start();
		}

	}

	@Override
	public void surfaceChanged(SurfaceHolder holder, int format, int width,
			int height)
	{
		if(mySurfaceViewThread!=null)
		{
			mySurfaceViewThread.OnWindowsResize(width, height);
		}

	}

	@Override
	public void surfaceDestroyed(SurfaceHolder holder)
	{
		hasSurface=false;
		Pause();

	}

	void Init()
	{
		holder = getHolder();
		holder.addCallback(this);
		hasSurface = false;
	}

	void Resume()
	{
		if (mySurfaceViewThread == null)
		{
			mySurfaceViewThread = new MySurfaceViewThread();
			if (hasSurface)
			{
				mySurfaceViewThread.start();
			}
		}
	}

	void Pause()
	{
		if (mySurfaceViewThread != null)
		{
			mySurfaceViewThread.setDone(true);
			mySurfaceViewThread = null;
		}
	}

	class MySurfaceViewThread extends Thread
	{
		boolean done;

		public boolean isDone()
		{
			return done;
		}

		public void setDone(boolean done)
		{
			this.done = done;
		}

		MySurfaceViewThread()
		{
			super();
			done = false;

		}

		
		
		public void Run()
		{
			SurfaceHolder surfaceHolder = holder;

			while (!done)
			{
				Canvas canvas = surfaceHolder.lockCanvas();

				surfaceHolder.unlockCanvasAndPost(canvas);
			}
		}
		
		public void  OnWindowsResize(int w,int h)
		{
			
			
			
		}
	}
}
