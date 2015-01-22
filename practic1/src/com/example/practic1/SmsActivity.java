package com.example.practic1;

import android.R.string;
import android.app.Activity;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.telephony.gsm.SmsMessage;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class SmsActivity extends Activity {

	EditText phoneEditText, smsEditText;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_sms);

		Button sendButton = (Button) findViewById(R.id.buttonSendSMS);

		phoneEditText = (EditText) findViewById(R.id.editTextPhone);

		smsEditText = (EditText) findViewById(R.id.editTextSMS);

		sendButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				
				String phoneNum = phoneEditText.getText().toString();// ��ȡ�绰����
				String smsContent = smsEditText.getText().toString();// ��ȡ��������
				SmsManager smsManager = SmsManager.getDefault();
				smsManager.sendTextMessage(phoneNum, null, smsContent, null,
						null);
				Toast.makeText(SmsActivity.this, "����", Toast.LENGTH_SHORT)
						.show();
			}
		});

	}
}
