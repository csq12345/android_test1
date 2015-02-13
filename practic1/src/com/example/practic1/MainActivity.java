package com.example.practic1;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.Socket;
import java.net.URI;

import javax.net.SocketFactory;

import org.apache.http.HttpEntity;
import org.apache.http.HttpHost;
import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.ResponseHandler;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.client.utils.URIUtils;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EncodingUtils;

import com.example.practic1.R.id;

import android.R.bool;
import android.R.string;
import android.app.Activity;
import android.app.Notification.Action;
import android.content.ComponentName;
import android.content.ContentValues;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.ServiceConnection;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursor;
import android.database.sqlite.SQLiteDatabase;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.Uri;
import android.os.Binder;
import android.os.Bundle;
import android.os.Handler;
import android.os.IBinder;
import android.os.Message;
import android.util.Log;
import android.util.Xml.Encoding;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends Activity {
	SQLiteDatabase sqLiteDatabase;
	Button threadButton;
	InputStream inputStream;
	OutputStream outputStream;

	Socket clientSocket;

	Handler messageHandler;

	Button serviceStartButton;
	Button serviceStopButton;
	Button serviceConnButton;
	Button serviceDesconnButton;

	Button regButton;
	Button unregButton;

	MyPracticeService mps;
	ServiceConnection serviceConnection;

	MyBroadcastReceiver myBroadcastReceiver;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		// /[SQLite

		// /[创建数据库
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
		// /]

		// /[ 读取数据库
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

		// /]
		// /]

		// /[ httpclient

		threadButton = (Button) findViewById(R.id.buttonThread);
		threadButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

				Thread thread = new Thread(new Runnable() {

					@Override
					public void run() {
						// TODO Auto-generated method stub
						HttpClient httpClient = new DefaultHttpClient();// 定义httpclient
						String myUri = "http://www.baidu.com";

						byte[] bytearray = new byte[4089];

						HttpGet httpGet = new HttpGet(myUri);
						try {
							URI uri2 = URIUtils.createURI("http",
									"www.baidu.com", 80, "", "", "");
							HttpResponse httpResponse = httpClient
									.execute(httpGet);

							HttpEntity httpEntity = httpResponse.getEntity();
							if (httpEntity != null) {
								InputStream inputStream = httpEntity
										.getContent();
								inputStream.read(bytearray);

								inputStream.close();

								String webdata = EncodingUtils.getString(
										bytearray, "utf-8");

								System.out.println(webdata);

								threadButton.setText("执行完成");

							}
						} catch (Exception e) {
							// TODO: handle exception
							Log.d("httpclient", e.getMessage());

						}
					}
				});
				//
				thread.start();

			}
		});

		// HttpClient httpClient = new DefaultHttpClient();// 定义httpclient
		// String myUri = "http://www.baidu.com";
		//
		//
		//
		// byte[] bytearray = new byte[4089];
		//
		// HttpGet httpGet = new HttpGet(myUri);
		// try {
		// URI uri2=URIUtils.createURI("http", "www.baidu.com", 80, "", "", "");
		// HttpResponse httpResponse = httpClient.execute(httpGet);
		//
		// HttpEntity httpEntity = httpResponse.getEntity();
		// if (httpEntity != null) {
		// InputStream inputStream = httpEntity.getContent();
		// inputStream.read(bytearray);
		//
		// inputStream.close();
		//
		// String webdata= EncodingUtils.getString(bytearray, "gbk");
		//
		// Toast toast=Toast.makeText(MainActivity.this, webdata,
		// Toast.LENGTH_SHORT);
		// toast.show();
		// }
		// } catch (Exception e) {
		// // TODO: handle exception
		// Log.d("httpclient", e.getMessage());
		// thread.start();
		// }

		// /]

		// /[ socket客户端

		messageHandler = new Handler() {

			@Override
			public void handleMessage(Message msg) {
				// TODO Auto-generated method stub
				super.handleMessage(msg);

				Toast toast = Toast.makeText(MainActivity.this,
						msg.obj.toString(), Toast.LENGTH_SHORT);
				toast.show();
			}

		};

		Button linkButton = (Button) findViewById(R.id.buttonLink);
		linkButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

				Thread thread = new Thread(new Runnable() {
					public void run() {
						try {
							EditText ipEditText = (EditText) findViewById(R.id.editTextPhone);
							String ip = ipEditText.getText().toString();
							int port = 6666;
							clientSocket = new Socket(ip, port);

							System.out.println("Client is created! site:" + ip
									+ " port:" + port);
							// Toast.makeText (MainActivity.this,"创建连接",
							// Toast.LENGTH_SHORT).show();
							Message msg = new Message();
							msg.obj = "连接成功";
							messageHandler.sendMessage(msg);

						} catch (IOException e) {
							// TODO Auto-generated catch block
							Log.e("socket", e.getMessage());
						}
					}
				});
				thread.start();

			}
		});

		Button sendButton = (Button) findViewById(R.id.buttonSend);
		sendButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				// 获取文本输入 发送信息
				EditText et = (EditText) findViewById(R.id.editTextSend);
				String s = et.getText().toString();
				byte[] buf = EncodingUtils.getBytes(s, "gbk");
				try {

					if (outputStream == null) {
						outputStream = clientSocket.getOutputStream();
					}

					outputStream.write(buf);
					outputStream.flush();
				} catch (Exception e) {
					// TODO Auto-generated catch block

					Log.e("sendex", e.getMessage());
				}

			}
		});
		// /]

		// /[短信activity

		Button smsButton = (Button) findViewById(R.id.buttonSMSActivity);
		smsButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

				Intent smsIntent = new Intent();
				smsIntent.setClass(MainActivity.this, SmsActivity.class);
				MainActivity.this.startActivity(smsIntent);
			}
		});

		// /]

		// /[ GPS

		Button gpsButton = (Button) findViewById(id.buttonGpsActivity);
		gpsButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent gpsIntent = new Intent();
				gpsIntent.setClass(MainActivity.this, GpsActivity.class);
				MainActivity.this.startActivity(gpsIntent);

			}
		});
		// /]

		// /[service

		serviceStartButton = (Button) findViewById(R.id.buttonService);
		serviceStopButton = (Button) findViewById(R.id.buttonServiceClose);
		serviceConnButton = (Button) findViewById(R.id.buttonConnService);
		serviceDesconnButton = (Button) findViewById(R.id.buttonDeConnService);

		serviceStartButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

				try {
					Intent startIntent = new Intent();
					startIntent.setClass(MainActivity.this,
							MyPracticeService.class);

					ComponentName componentName = startService(startIntent);

					String sername = componentName.getClassName();
					Toast.makeText(MainActivity.this, sername,
							Toast.LENGTH_SHORT).show();

				} catch (Exception e) {
					// TODO: handle exception
					Toast.makeText(MainActivity.this, e.getMessage(),
							Toast.LENGTH_SHORT).show();
				}

			}
		});

		serviceStopButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				try {
					Intent startIntent = new Intent();
					startIntent.setClass(MainActivity.this,
							MyPracticeService.class);

					boolean b = stopService(startIntent);

					if (b) {
						Toast.makeText(MainActivity.this, "服务关闭",
								Toast.LENGTH_SHORT).show();
					} else {
						Toast.makeText(MainActivity.this, "关闭失败",
								Toast.LENGTH_SHORT).show();
					}

				} catch (Exception e) {
					// TODO: handle exception
					Toast.makeText(MainActivity.this, e.getMessage(),
							Toast.LENGTH_SHORT).show();
				}
			}
		});

		serviceConnButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				try {

					if (serviceConnection == null) {
						serviceConnection = new ServiceConnection() {

							@Override
							public void onServiceDisconnected(ComponentName name) {
								// TODO Auto-generated method stub

							}

							@Override
							public void onServiceConnected(ComponentName name,
									IBinder service) {
								// TODO Auto-generated method stub

								MyPracticeService.LocalBinder binder = ((MyPracticeService.LocalBinder) service);
								mps = binder.GetService();
							}
						};
					}

					Intent bindIntent = new Intent(MainActivity.this,
							MyPracticeService.class);
					boolean b = bindService(bindIntent, serviceConnection,
							BIND_AUTO_CREATE);
					if (b) {
						Toast.makeText(MainActivity.this, "绑定成功",
								Toast.LENGTH_SHORT).show();
					}

					else {
						Toast.makeText(MainActivity.this, "绑定失败",
								Toast.LENGTH_SHORT).show();
					}
				} catch (Exception e) {
					// TODO: handle exception
					Toast.makeText(MainActivity.this, e.getMessage(),
							Toast.LENGTH_SHORT).show();
				}
			}
		});

		serviceDesconnButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				try {

					unbindService(serviceConnection);

					Toast.makeText(MainActivity.this, "断开服务",
							Toast.LENGTH_SHORT).show();

				} catch (Exception e) {
					// TODO: handle exception
					Toast.makeText(MainActivity.this, e.getMessage(),
							Toast.LENGTH_SHORT).show();
				}
			}
		});

		// /]

		// /[ broadreceiver

		regButton = (Button) findViewById(R.id.buttonReg);
		unregButton = (Button) findViewById(R.id.buttonUnReg);

		regButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub

				if (myBroadcastReceiver != null) {
					unregisterReceiver(myBroadcastReceiver);
				} else {
	
				
					
					IntentFilter reginIntentFilter = new IntentFilter("android.provider.Telephony.SMS_RECEIVED");
					myBroadcastReceiver = new MyBroadcastReceiver();
					registerReceiver(myBroadcastReceiver, reginIntentFilter);
					
					Toast.makeText(MainActivity.this, "注册",
							Toast.LENGTH_SHORT).show();
				}

			}
		});

		unregButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				unregisterReceiver(myBroadcastReceiver);
			}
		});

		// /]

		Button exitButton = (Button) findViewById(id.buttonExit);
		exitButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				MainActivity.this.finish();
			}
		});
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
