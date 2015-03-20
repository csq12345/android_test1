package com.example.paad_15_18;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;

import android.content.Context;
import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioTrack;
import android.os.Environment;
import android.os.SystemClock;
import android.util.Log;
import android.widget.Toast;

public class MyTrack
{

	AudioTrack audioTrack;
	int buffbytesize = 16384;
	Context thisContext;
	String tag = "MyRecordTAg";
	
	boolean playing=false;
	
	public MyTrack(Context context)
	{
		thisContext = context;
		audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC, 11025,
				AudioFormat.CHANNEL_CONFIGURATION_MONO,
				AudioFormat.ENCODING_PCM_16BIT, buffbytesize,
				AudioTrack.MODE_STREAM);
		
	}

	public void Play()
	{
		Thread t1 = new Thread(new Runnable()
		{

			@Override
			public void run()
			{
				Log.d(tag, "��ʼ����");
				// TODO Auto-generated method stub
				File playFile = new File(Environment
						.getExternalStorageDirectory(), "z_record.pcm");
				if (playFile.exists())
				{
					try
					{
						short[] audioShorts = new short[buffbytesize];
						InputStream inputStream = new FileInputStream(playFile);
						BufferedInputStream bufferedInputStream = new BufferedInputStream(
								inputStream);
						DataInputStream dataInputStream = new DataInputStream(
								bufferedInputStream);

						audioTrack.play();;
						Log.d(tag, "��������");
						playing=true;
						while (dataInputStream.available() > 0&&playing)
						{
							int len = 0;
							for (int i = 0; i < audioShorts.length; i++)
							{
								if (dataInputStream.available() > 0)
								{
									audioShorts[i] = dataInputStream
											.readShort();
									len++;
								}
							}
							audioTrack.write(audioShorts, 0, len);
							Log.d(tag, "����"+len);	
							SystemClock.sleep(200);
						}
						dataInputStream.close();
						bufferedInputStream.close();
						inputStream.close();
						Log.d(tag, "�������");	
					} catch (Exception ex)
					{
						// TODO: handle exception
						Log.d(tag,ex.getMessage());
					}

				} else
				{
					Log.d(tag,"δ�ҵ��ļ�");
				}
			}
		});
		t1.start();

	}

	public void StopPlay()
	{
		// TODO Auto-generated method stub
		audioTrack.stop();
		playing=false;
	}
}
