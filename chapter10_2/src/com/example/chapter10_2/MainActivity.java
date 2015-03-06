package com.example.chapter10_2;

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

	Button myStartButton;
	Button myEndButton;
	
	ProgressBar myProgressBar;
	
	boolean isRunning=true;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        myProgressBar=(ProgressBar)findViewById(R.id.progressBar1);
        myStartButton=(Button)findViewById(R.id.buttonStart);
        
        myEndButton=(Button)findViewById(R.id.buttonEnd);
        
        myStartButton.setOnClickListener(this);
        
        myEndButton.setOnClickListener(this);
        
    }

    
    private Handler handler=new Handler()
    {
    	
    	public void handleMessage(Message msg) {
			myProgressBar.incrementProgressBy(5);
		}
    	
    };
    
    class MyRunnable implements Runnable
    {

		@Override
		public void run() {
			for (int i = 0; i < 20&isRunning; i++) {
				SystemClock.sleep(1000);
				
				Message msg=handler.obtainMessage();
				handler.sendMessage(msg);
			}
		}
    	
    }
    
    public void onClick(View view)
    {
    	int viewid=view.getId();
    	if(R.id.buttonStart==viewid)
    	{
    		//¿ªÊ¼
    		myProgressBar.setProgress(0);
    		isRunning=true;
    		Thread myThread=new Thread(new MyRunnable());
    		myThread.start();
    		
    	}
    	else if(R.id.buttonEnd==viewid)
    	{
    		//½áÊø
    		isRunning=false;
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
}
