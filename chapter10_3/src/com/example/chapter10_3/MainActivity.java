package com.example.chapter10_3;

import android.R.integer;
import android.app.Activity;
import android.app.ActivityManager;
import android.content.ComponentName;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ProgressBar;


public class MainActivity extends Activity implements OnClickListener {

	String Tag = "MainActivity";

	Button myButton;

	ProgressBar myProgressBar;

	Handler myHandler;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		myButton = (Button) findViewById(R.id.buttonSend);
		myButton.setOnClickListener(this);

		myProgressBar = (ProgressBar) findViewById(R.id.progressBar1);
		myHandler = new MyHandler();
		
	
	}

	class MyHandler extends Handler {

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			Bundle bundle = msg.getData();

			int percent = bundle.getInt("percent");
			myProgressBar.setProgress(percent);
			if (percent >= 100) {
				return;
			}

		}

	}



	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}


	@Override
	public void onClick(View v) {
		if (v.getId() == R.id.buttonSend) {

			 myHandler.post(myRunnable);

			

		}
	}

	Runnable myRunnable = new Runnable() {
		int percent = 0;

		@Override
		public void run() {
			Log.d(Tag, "my runnable run thread name is :"
					+ Thread.currentThread().getName());

			percent += 10;

			Message msg = new Message();
			Bundle bundle = new Bundle();
			bundle.putInt("percent", percent);

			msg.setData(bundle);

			SystemClock.sleep(1000);

			myHandler.sendMessage(msg);

		}
	};
}
