package com.example.practic2;

import java.util.Date;
import java.util.Timer;

import android.R.id;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.webkit.JavascriptInterface;
import android.webkit.WebView;
import android.widget.Button;
import android.os.Build;


public class WebKitActivity extends Activity {

	Button loadButton,returnButton;
	
	WebView myWebView;
	
	/** Called when the activity is first created. */
	@SuppressLint({ "JavascriptInterface", "SetJavaScriptEnabled" }) @Override
	public void onCreate(Bundle savedInstanceState) {
	    super.onCreate(savedInstanceState);
	
	    // TODO Auto-generated method stub
	    setContentView(R.layout.activity_webkit);
	    
	    loadButton=(Button)findViewById(R.id.buttonLoad);
	    returnButton=(Button)findViewById(R.id.buttonReturn);
	    
	    myWebView=(WebView)findViewById(R.id.webView1);
	    ///[ 设置浏览器属性
	    myWebView.getSettings().setJavaScriptEnabled(true);
	    
	    CWJS cwjs=new CWJS();//定义自定义的javascript内容对象
	    myWebView.addJavascriptInterface(cwjs, "CWJS");
 
	    
	    ///]
	    
	    loadButton.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				myWebView.loadData("<html><head></head><body><script>"+
        "function gettime() {"+
            "var bt =document. getElementById('bt');"+
         " bt.value = CWJS.GetDateTime()}"+
    "</script>  <input id='bt' type='button' value='GetTime' onclick='gettime()'></body></html>"
						,"text/html","utf-8");
				
				
				
				
			}
		});
	    
	    returnButton.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				
			}
		});
	}

}

class CWJS{
	@JavascriptInterface
	public String GetDateTime() {
		
	return new Date().toString();
	}
}

