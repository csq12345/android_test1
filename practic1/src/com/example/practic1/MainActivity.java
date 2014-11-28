package com.example.practic1;

import java.io.IOException;
import java.io.InputStream;

import org.apache.http.HttpEntity;
import org.apache.http.HttpHost;
import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.ResponseHandler;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.HttpParams;
import org.apache.http.protocol.HttpContext;

import android.R.bool;
import android.R.string;
import android.app.Activity;
import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity {
	SQLiteDatabase sqLiteDatabase;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		// /[SQLite

		// /{创建数据库
		Button createButton = (Button) findViewById(R.id.buttonCreateDB);
		Button readButton = (Button) findViewById(R.id.buttonReadDB);

		createButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				try {
					sqLiteDatabase = openOrCreateDatabase("testdb.sdf",
							MODE_PRIVATE, null);
					String createTableSQL = "create table t1 (names text,ages integer )";
					sqLiteDatabase.execSQL(createTableSQL);

					ContentValues contentValues = new ContentValues();

					contentValues.put("names", "张三");
					contentValues.put("ages", 100);

					long count = sqLiteDatabase.insert("t1", null,
							contentValues);

					// 显示成功插入的数量
					Toast toast = Toast.makeText(MainActivity.this, "成功插入"
							+ count, Toast.LENGTH_SHORT);
					toast.show();

				} catch (Exception e) {
					// TODO: handle exception
					Log.d("创建表异常", e.getMessage());
				}

			}
		});
		// /}

		// /{ 读取数据库
		readButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				// try {
				Cursor cursor = sqLiteDatabase.query("t1", null, "ages=100",
						null, null, null, null);

				boolean b = cursor.moveToNext();
				if (b) {
					int datacount = cursor.getCount();
					Toast toast = Toast.makeText(MainActivity.this, datacount
							+ "", Toast.LENGTH_SHORT);
					toast.show();
				}
				// } catch (Exception e) {
				// // TODO: handle exception
				// Log.d("读取表异常", e.getMessage());
				// }

			}
		});

		// /}
		// /]

		// /[ httpclient
		Thread thread = new Thread();

		HttpClient httpClient = new DefaultHttpClient();// 定义httpclient
		String myUri = "http://www.baidu.com";

		byte[] bytearray = new byte[4089];

		HttpGet httpGet = new HttpGet(myUri);
		try {
			HttpResponse httpResponse = httpClient.execute(httpGet);

			HttpEntity httpEntity = httpResponse.getEntity();
			if (httpEntity != null) {
				InputStream inputStream = httpEntity.getContent();
				inputStream.read(bytearray);
			}
		} catch (Exception e) {
			// TODO: handle exception
		}

		// /]
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
