package com.example.practic1;

import java.io.Console;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

public class MyBroadcastReceiver extends BroadcastReceiver {

	@Override
	public void onReceive(Context context, Intent intent) {
		// TODO Auto-generated method stub
		
		Log.i("MyBroadcastReceiver","���յ��㲥");
		
		System.out.print("���յ��㲥");
		
		
	
	}

}
