package com.example.chapter11_4;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.os.RemoteException;
import android.util.Log;

public class StockService extends Service
{
String tag="StockService";
	public class StockServiceImpl extends IStockService.Stub
	{
		@Override
		public double getPrice(String ticket) throws RemoteException
		{
			// TODO Auto-generated method stub
			return 20.0;
		}

	}

	@Override
	public IBinder onBind(Intent intent)
	{
		// TODO Auto-generated method stub
		return new StockServiceImpl();
	}

	@Override
	public void onCreate()
	{
		Log.d(tag, "onCreate");
		super.onCreate();
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		Log.d(tag, "onStartCommand");
		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public void onDestroy()
	{
		Log.d(tag, "onDestroy");
		super.onDestroy();
	}

	@Override
	public boolean onUnbind(Intent intent)
	{
		Log.d(tag, "onUnbind");
		return super.onUnbind(intent);
	}

}
