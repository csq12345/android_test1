package com.cw.myattendants.service;

import android.app.Service;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.IBinder;

public class ListenGPSService extends Service
{
	LocationManager locationManager = null;
	Location_Listen location_Listen ;
	long minTime = 30000;
	float minDistance = 20;

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
			locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
			 location_Listen = new Location_Listen();
		}
		
		boolean gpsEnabled = locationManager
				.isProviderEnabled(LocationManager.GPS_PROVIDER);
		if (gpsEnabled)
		{

			locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER,
					minTime,
					minDistance,
					location_Listen);
					
					
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
		if(locationManager!=null)
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

	class Location_Listen implements LocationListener
	{

		@Override
		public void onLocationChanged(Location location)
		{
			// TODO Auto-generated method stub

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

}
