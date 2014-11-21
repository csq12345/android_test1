package com.example.practic1;

import android.R.bool;
import android.R.string;
import android.app.Activity;
import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursor;
import android.database.sqlite.SQLiteDatabase;
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

		// {SQLite
		Button createButton = (Button) findViewById(R.id.buttonCreateDB);
		Button readButton = (Button) findViewById(R.id.buttonReadDB);

		// {�������ݿ�
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

					contentValues.put("names", "����");
					contentValues.put("ages", 100);

					long count = sqLiteDatabase.insert("t1", null,
							contentValues);

					// ��ʾ�ɹ����������
					Toast toast = Toast.makeText(MainActivity.this, "�ɹ�����"
							+ count, Toast.LENGTH_SHORT);
					toast.show();

				} catch (Exception e) {
					// TODO: handle exception
					Log.d("�������쳣", e.getMessage());
				}

			}
		});
		// }

		// {��ȡ���ݿ�
		readButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
//				try {
					Cursor cursor = sqLiteDatabase.query("t1", null, "ages=100",
							null, null, null, null);

					boolean b = cursor.moveToNext();
					if (b) {
						int datacount = cursor.getCount();
						Toast toast = Toast.makeText(MainActivity.this, datacount
								+ "", Toast.LENGTH_SHORT);
						toast.show();
					}
//				} catch (Exception e) {
//					// TODO: handle exception
//					Log.d("��ȡ���쳣", e.getMessage());
//				}
				
			}
		});

		// }
		// }

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
