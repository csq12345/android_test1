package com.example.chanpter13_1;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;


public class MainActivity extends Activity {

	String tag="chapter13_1";
	ImageView imageView;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        imageView=(ImageView)findViewById(R.id.imageView1);
        
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
    
    InputStream OpenHttpConnection(String urlString) throws Exception
    {
    	InputStream inputStream=null;
    	int response=-1;
    	
    	URL url=new URL(urlString);
    	URLConnection connection=url.openConnection();
    	
    	if(!(connection instanceof HttpURLConnection))
    	{
    		throw new Exception("not an http connection");
    	}
    	
    	try
    	{
    		HttpURLConnection httpconn=(HttpURLConnection)connection;
    		httpconn.setInstanceFollowRedirects(true);
    		httpconn.setRequestMethod("GET");
    		httpconn.connect();
    		
    		response=httpconn.getResponseCode();
    		
    		if(response==HttpURLConnection.HTTP_OK){
    			inputStream=httpconn.getInputStream();
    		}
    		
    	}
    	catch(Exception ex)
    	{
    		Log.e(tag,ex.getLocalizedMessage());
    	}
    	
    	
		return inputStream;
    	
    }
    
    
    Bitmap DownLoadImage(String url)
    {
    	Bitmap bitmap=null;
    	InputStream inputStream=null;
    	try{
    		inputStream=OpenHttpConnection(url);
    		bitmap=BitmapFactory.decodeStream(inputStream);
    		inputStream.close();
    	}
    	catch(Exception ex)
    	{
    		Log.e(tag,ex.getLocalizedMessage());
    	}
    	return bitmap;
    }
    
    class DownloadImageTask extends AsyncTask<String, Void	, Bitmap>
    {

		@Override
		protected Bitmap doInBackground(String... params)
		{
			// TODO Auto-generated method stub
			return DownLoadImage(params[0]);
		}
    	
    }
    
    
}
