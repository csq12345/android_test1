package com.example.practic1;

import com.example.practic1.GpsActivity.MyLocationListener;

import android.app.Service;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Binder;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

public class MyPracticeService extends Service {
	LocationListener locationListener;
	LocationManager locationManager;
	public class LocalBinder extends Binder {

		public MyPracticeService GetService() {

			return MyPracticeService.this;
		}

	}

	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		Log.i("myPracticeService", "Bind");
		return null;
	}
	boolean CheckGPSIsOpen(LocationManager locationManager) {

		boolean b = locationManager
				.isProviderEnabled(LocationManager.GPS_PROVIDER);

		return b;
	}
	@Override
	public void onCreate() {
		// TODO Auto-generated method stub
		Log.i("myPracticeService", "Create");
		
		locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
		boolean b = CheckGPSIsOpen(locationManager);
		if (b) {
			//locationManager.setTestProviderEnabled(LocationManager.GPS_PROVIDER, true);

			locationListener=new MyLocationListener();
			
			locationManager.requestLocationUpdates(
					LocationManager.GPS_PROVIDER,
					1000, 
					1,
					locationListener);
		}
		
		super.onCreate();
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		// TODO Auto-generated method stub
		Log.i("myPracticeService", "Start");
		return super.onStartCommand(intent, flags, startId);
	}

	@Override
	public void onDestroy() {
		// TODO Auto-generated method stub
		Log.i("myPracticeService", "Destory");
		
locationManager.removeUpdates(locationListener);
		
		super.onDestroy();
	}

	@Override
	public boolean onUnbind(Intent intent) {
		Log.i("myPracticeService", "Unbind");
		// TODO Auto-generated method stub
		return super.onUnbind(intent);
	}
	class MyLocationListener implements LocationListener{

		@Override
		public void onLocationChanged(Location location) {
			// TODO Auto-generated method stub
			Log.i("gps app", "onLocationChanged");
			
		}

		@Override
		public void onStatusChanged(String provider, int status, Bundle extras) {
			// TODO Auto-generated method stub
			Log.i("gps app", "onStatusChanged");
		}

		@Override
		public void onProviderEnabled(String provider) {
			// TODO Auto-generated method stub
			Log.i("gps app", "onProviderEnabled");
		}

		@Override
		public void onProviderDisabled(String provider) {
			// TODO Auto-generated method stub
			Log.i("gps app", "onProviderDisabled");
		}
		
	}
}
