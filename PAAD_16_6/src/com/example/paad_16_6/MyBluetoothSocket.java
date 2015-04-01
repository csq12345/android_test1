package com.example.paad_16_6;

import java.io.InputStream;
import java.util.UUID;

import android.R.string;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.util.Log;

public class MyBluetoothSocket
{
	BluetoothSocket transferSocket;

	private UUID StartServerSocket(BluetoothAdapter bluetoothAdapter)
	{
		// TODO Auto-generated method stub
		UUID uuid = UUID.fromString("a60f35f0-b93a-11de-8a39-08002009c666");
		String nameString = "bluetoothserver";

		final String tag = "bluetoothsocket";

		try
		{
			final BluetoothServerSocket btserver = bluetoothAdapter
					.listenUsingRfcommWithServiceRecord(nameString, uuid);

			Thread acceptThread = new Thread(new Runnable()
			{

				@Override
				public void run()
				{
					try
					{
						// 客户端连接建立前保持阻塞
						BluetoothSocket serverSocket = btserver.accept();

						Log.d(tag, "有设备接入");
						// 开始监听
						ListenFormessage(serverSocket);
						// 添加对用来发送消息的套接字
						transferSocket = serverSocket;

					} catch (Exception ex)
					{
						Log.e(tag, ex.getMessage());
					}

				}
			});

			acceptThread.start();

		} catch (Exception ex)
		{
			Log.e(tag, ex.getMessage());
		}
		return uuid;
	}

	boolean listening = false;

	void ListenFormessage(BluetoothSocket serverSocket)
	{
		listening = true;

		int bufferSize = 1024;
		byte[] buffer = new byte[bufferSize];

		try
		{
			InputStream inStream = serverSocket.getInputStream();

			int bytelen = -1;

			while (listening)
			{
				bytelen = inStream.read(buffer);
				if (bytelen != -1)
				{
					String result = "";

					
				}

			}

		} catch (Exception ex)
		{
			// TODO: handle exception
		}

	}
}
