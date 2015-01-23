package com.example.practic1;

import android.R.bool;
import android.app.Activity;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class GpsActivity extends Activity {

	Button openButton;
	Button closeButton;

	EditText altitudeEditText,longitudeEditText;
	
	LocationListener locationListener;
		LocationManager locationManager;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		this.setContentView(R.layout.activity_gps);

		openButton = (Button) findViewById(R.id.buttonOpenGPS);
		closeButton = (Button) findViewById(R.id.buttonCloseGPS);

		altitudeEditText=(EditText)findViewById(R.id.editText1);
		longitudeEditText=(EditText)findViewById(R.id.editText2);
		
		
		openButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

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
			}
		});

		closeButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				locationManager.removeUpdates(locationListener);
			}
		});

	}

	// 检查gps是否开启
	boolean CheckGPSIsOpen(LocationManager locationManager) {

		boolean b = locationManager
				.isProviderEnabled(LocationManager.GPS_PROVIDER);

		if (b) {
			Toast.makeText(GpsActivity.this, "GPS正常", Toast.LENGTH_SHORT)
					.show();
			return true;
		}
		return false;
	}
	
	class MyLocationListener implements LocationListener{

		@Override
		public void onLocationChanged(Location location) {
			// TODO Auto-generated method stub
			Log.i("gps app", "onLocationChanged");
			if(location!=null)
			{
			
				String latitude=location.getLatitude()+"";
				String longitude=location.getLongitude()+"";
				
				altitudeEditText.setText(latitude);
				longitudeEditText.setText(longitude);
			}
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
