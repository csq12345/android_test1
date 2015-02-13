package com.example.practic3;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends Activity{
Button openButton;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(com.example.practic3.R.layout.activity_main);

		openButton=(Button)findViewById(com.example.practic3.R.id.button1);
		openButton.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
			
				Intent openIntent=new Intent();
				openIntent.setClassName("com.example.practic1", "com.example.practic1.MainActivity");
				
				MainActivity.this .startActivity(openIntent);
				
			}
		});
	}

}
