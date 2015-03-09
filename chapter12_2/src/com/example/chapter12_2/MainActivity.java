package com.example.chapter12_2;

import com.example.chapter12_2.R.id;

import android.R.integer;
import android.app.Activity;
import android.os.Bundle;
import android.telephony.CellLocation;
import android.telephony.TelephonyManager;
import android.telephony.gsm.GsmCellLocation;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity
{

	Button getButton;

	TextView textViewMCC;
	TextView textViewMNC;
	TextView textViewLAC;
	TextView textViewCID;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		getButton = (Button) findViewById(R.id.buttonGet);
		textViewMCC = (TextView) findViewById(R.id.textViewMCC);
		textViewMNC = (TextView) findViewById(R.id.textViewMNC);
		textViewLAC = (TextView) findViewById(R.id.textViewLAC);
		textViewCID = (TextView) findViewById(R.id.textViewCID);

		getButton.setOnClickListener(new OnClickListener()
		{

			@Override
			public void onClick(View v)
			{
				getLocationByCell();

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

	void getLocationByCell()
	{
		try
		{
			Scell scell = GetCellInfo();
			//SItude sItude = GetItude();
			
			textViewMCC.setText(Integer.toString(scell.MCC));
			textViewMNC.setText(Integer.toString(scell.MNC));
			String lac=Integer.toString(scell.LAC);
			textViewLAC.setText(lac);
			textViewCID.setText(Integer.toString(scell.CID));

		} catch (Exception ex)
		{
			Toast.makeText(this,ex.getMessage(), Toast.LENGTH_SHORT).show();
		}
	}

	Scell GetCellInfo()
	{
		Scell scell = new Scell();

		TelephonyManager telephonyManager = (TelephonyManager) getSystemService(TELEPHONY_SERVICE);

		GsmCellLocation cellLocation = (GsmCellLocation)telephonyManager.getCellLocation();

		if(cellLocation==null)
		{
			Toast.makeText(this, "cellLocationΪnull", Toast.LENGTH_SHORT).show();
			return scell;
		}
		String operator=	telephonyManager.getNetworkOperator();
		
		scell.setMCC(Integer.parseInt(operator.substring(0, 3)));
		scell.setMNC(Integer.parseInt(operator.substring(3)));
		scell.setCID(cellLocation.getCid());
		scell.setLAC(cellLocation.getLac());
		
		
		return scell;
	}

	SItude GetItude()
	{
		return null;
	}

}
