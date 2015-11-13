package com.cw.myattendants.service;

import java.util.Iterator;

import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.location.Criteria;
import android.location.GpsSatellite;
import android.location.GpsStatus;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.IBinder;
import android.text.AndroidCharacter;


//GPS后台Service
public class ListenGPSService extends Service
{
	LocationManager locationManager = null;
	Location_Listen location_Listen;
	long minTime = 3000;
	float minDistance = 100;

	@Override
	public IBinder onBind(Intent intent)
	{
		// TODO Auto-generated method stub
		return null;
	}


	@Override
	public void onCreate()
	{
		// TODO Auto-generated method stub
		if (locationManager == null)
		{
			locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);//获取定位服务
			location_Listen = new Location_Listen();//创建一个定位监听
		}

		boolean gpsEnabled = locationManager
				.isProviderEnabled(LocationManager.GPS_PROVIDER);//获取定位服务是否启用
		if (gpsEnabled)
		{
			locationManager.requestLocationUpdates(
					LocationManager.GPS_PROVIDER, minTime, minDistance,
					location_Listen);//向定位服务注册监听 当定位发生变化时 会触发监听
				
			locationManager.addGpsStatusListener(new GpsStatuListen());//添加一个gps状态监听
		}
		super.onCreate();
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId)
	{
		// TODO Auto-generated method stub
		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public void onDestroy()
	{
		// TODO Auto-generated method stub
		//销毁向定位服务注册的监听
		if (locationManager != null)
		{
			locationManager.removeUpdates(location_Listen);
		}
		super.onDestroy();
	}

	@Override
	public boolean onUnbind(Intent intent)
	{
		// TODO Auto-generated method stub
		return super.onUnbind(intent);
	}

	String intentTag = "com.cw.myattendants.service.ListenGPSService";
	int count=0;
	
	//gpslocationg监听
	class Location_Listen implements LocationListener
	{

		@Override
		public void onLocationChanged(Location location)
		{
			// TODO Auto-generated method stub

			Intent intent = new Intent(intentTag);
			Bundle bundle = new Bundle();
			bundle.putDouble("Latitude", location.getLatitude());// 经度
			bundle.putDouble("Longitude", location.getLongitude());// 维度
			bundle.putDouble("SatelliteCount",count);//卫星数
			intent.putExtra("gpsbundle", bundle);

			sendBroadcast(intent);

		}

		@Override
		public void onStatusChanged(String provider, int status, Bundle extras)
		{
			// TODO Auto-generated method stub
			

		}

		@Override
		public void onProviderEnabled(String provider)
		{
			// TODO Auto-generated method stub

		}

		@Override
		public void onProviderDisabled(String provider)
		{
			// TODO Auto-generated method stub

		}

	}

	//gpsstatu����
	class GpsStatuListen implements GpsStatus.Listener
	{

		@Override
		public void onGpsStatusChanged(int event)
		{
			// TODO Auto-generated method stub
			GpsStatus gpsStatus = locationManager.getGpsStatus(null);
			Iterator<GpsSatellite> gpsIterable = gpsStatus.getSatellites()
					.iterator();
			 count = 0;
			for (GpsSatellite iterable_element; gpsIterable.hasNext();)
			{
				count++;
			}
		}
		
	}
	
}
