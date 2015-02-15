package com.cw.gpstools.WorkService;

import android.app.Service;
import android.content.Intent;
import android.location.LocationManager;
import android.os.IBinder;
import android.util.Log;

public class GPSService extends Service {

	GPSServiceLocationListener gpsServiceLocationListener;
	LocationManager locationManager ;
	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		Log.i("GPSService", "onBind");

		return null;
	}

	@Override
	public void onCreate() {
		// TODO Auto-generated method stub
		super.onCreate();

		Log.i("GPSService", "onCreate");

	 locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);

		String provider=LocationManager.GPS_PROVIDER;
		long minTime=10;
		long minDistance=100;
		
	 gpsServiceLocationListener=new 
			GPSServiceLocationListener();
		locationManager.requestLocationUpdates(provider, 
				minTime, 
				minDistance, 
				gpsServiceLocationListener);
	
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		// TODO Auto-generated method stub
		Log.i("GPSService", "onStartCommand");
		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public void onDestroy() {
		// TODO Auto-generated method stub
		super.onDestroy();

		Log.i("GPSService", "onDestroy");
		locationManager.removeUpdates(gpsServiceLocationListener);
		
	}

	@Override
	public boolean onUnbind(Intent intent) {
		// TODO Auto-generated method stub
		return super.onUnbind(intent);
	}

	@Override
	public void onRebind(Intent intent) {
		// TODO Auto-generated method stub
		super.onRebind(intent);
	}

}
