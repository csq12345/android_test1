package com.example.paad_15_18;

import java.io.BufferedOutputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;
import android.os.Environment;
import android.util.Log;

public class MyRecord
{
	AudioRecord myAudioRecord;
	boolean reding = false;
	int bufferSizeInBytes;

	String tag = "MyRecordTAg";

	public MyRecord()
	{
		bufferSizeInBytes = AudioRecord.getMinBufferSize(22050,
				AudioFormat.CHANNEL_IN_MONO, AudioFormat.ENCODING_PCM_16BIT);

		myAudioRecord = new AudioRecord(MediaRecorder.AudioSource.MIC, 22050,
				AudioFormat.CHANNEL_IN_MONO, AudioFormat.ENCODING_PCM_16BIT,
				bufferSizeInBytes);

	}

	public void Start()
	{
		myAudioRecord.startRecording();
		reding = true;
		Thread recordThread = new Thread(new Runnable()
		{

			@Override
			public void run()
			{
				FileOutputStream outStream=null;
				try
				{
					File saveFile = new File(Environment
							.getExternalStorageDirectory(), "z_record.pcm");

					if (saveFile.exists())// 如果文件存在 就删除文件
					{
						saveFile.delete();
					}
					saveFile.createNewFile();

					 outStream = new FileOutputStream(saveFile);

					 BufferedOutputStream bufferedOutputStream=new BufferedOutputStream(outStream);
					 DataOutputStream dataOutputStream=new DataOutputStream(bufferedOutputStream);
					short[] audioData = new short[bufferSizeInBytes];
					int len = 0;
					while (reding)
					{
						len = myAudioRecord.read(audioData, 0,
								bufferSizeInBytes);
						for(int i=0;i<len;i++)
						{
							dataOutputStream.writeShort(audioData[i]);
						}
					
						Log.d(tag, "写入 "+len);
					}
					dataOutputStream.close();
					bufferedOutputStream.close();
					outStream.close();
				} catch (Exception ex)
				{
					Log.e(tag, ex.getMessage());		
				}
				finally{
		
				}
			}
		});
		
		recordThread.start();
	}

	public void Stop()
	{
		
		myAudioRecord.stop();
		reding=false;
	}

}
