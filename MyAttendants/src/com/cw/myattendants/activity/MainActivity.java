package com.cw.myattendants.activity;

import android.app.Activity;
import android.app.ActivityManager;
import android.app.ActivityManager.RunningServiceInfo;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import com.cw.myattendants.R;
import com.cw.myattendants.broadcastreceiver.ReceiverGPSLocationInfo;
import com.cw.myattendants.service.ListenGPSService;

import java.util.List;

public class MainActivity extends Activity implements OnClickListener
{

    Button startButton;
    Button stopButton;
    Button exitButton;
    Button registerGpsButton;
    Button unregisterGpsButton;

    TextView latiduteTextView, longiduTextView, satalliteTextView, bundelTextView;

    //接受包计数
    int bunblecount = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        // TODO Auto-generated method stub
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        startButton = (Button) findViewById(R.id.buttonStartSer);
        stopButton = (Button) findViewById(R.id.buttonStopSer);
        exitButton = (Button) findViewById(R.id.buttonExit);

        registerGpsButton = (Button) findViewById(R.id.buttonRegisterGPS);
        unregisterGpsButton = (Button) findViewById(R.id.buttonUnRegisterGPS);

        startButton.setOnClickListener(this);
        stopButton.setOnClickListener(this);
        exitButton.setOnClickListener(this);

        registerGpsButton.setOnClickListener(this);
        unregisterGpsButton.setOnClickListener(this);

        longiduTextView = (TextView) findViewById(R.id.textViewLongitude);
        latiduteTextView = (TextView) findViewById(R.id.textViewLatidute);
        satalliteTextView = (TextView) findViewById(R.id.textViewSatellite);
        bundelTextView = (TextView) findViewById(R.id.textViewBundelCount);
    }

    @Override
    public void onClick(View v)
    {
        int vid = v.getId();
        switch (vid)
        {
            case R.id.buttonStartSer:
            {
                StartGPS();
            }
            break;
            case R.id.buttonStopSer:
            {

                StopGPS();
            }
            break;
            case R.id.buttonExit:
            {
                finish();

            }
            break;
            case R.id.buttonRegisterGPS:// 注册gps
            {
                Register();
            }
            break;
            case R.id.buttonUnRegisterGPS:// 注销gps
            {
                UnRegister();
            }
            break;
        }

    }

    // /[ GPS

    void StartGPS()
    {
        if (!CheckServiceIsRuning(ListenGPSService.class))
        {
            Intent gpsIntent = new Intent(this, ListenGPSService.class);

            startService(gpsIntent);

            Toast.makeText(this, "服务启动", Toast.LENGTH_SHORT).show();
        } else
        {
            Toast.makeText(this, "服务重复启动", Toast.LENGTH_SHORT).show();
        }
    }

    void StopGPS()
    {
        Intent gpsIntent = new Intent(this, ListenGPSService.class);
        stopService(gpsIntent);
    }

    String intentTag = "com.cw.myattendants.service.ListenGPSService";
    Handler gpsHandler;
    ReceiverGPSLocationInfo receiverGPSLocationInfo;

    //注册服务
    void Register()
    {
        if (receiverGPSLocationInfo == null)
        {
            gpsHandler = new Handler(new Handler.Callback()
            {

                @Override
                public boolean handleMessage(Message msg)
                {
                    try
                    {
                        Log.d("handler", "接收到handler ");
                        //接收消息计数加1
                        bunblecount++;
                        Bundle bundle = msg.getData();
//
//                        double longitude = bundle.getDouble("Longitude");// 经度
//                        double latitude = bundle.getDouble("Latitude");// 纬度
//
//                        int count = bundle.getInt("SatelliteCount");
//                        Log.d("handler", count + " " + longitude + " " + latitude);
//                        longiduTextView.setText(String.valueOf(longitude));
                        latiduteTextView.setText(String.valueOf(bundle.getString("timecount")));
                        String str=bundle.getString("str");
                        if(str!=null)
                        {
                            satalliteTextView.setText(str);
                        }



                        bundelTextView.setText(String.valueOf(bunblecount));
                        return true;
                    } catch (Exception ex)
                    {
                        Log.d("handler", ex.getMessage());
                        return false;
                    }

                }
            });

            IntentFilter intentFilter = new IntentFilter(intentTag);
            receiverGPSLocationInfo = new ReceiverGPSLocationInfo(gpsHandler);

            registerReceiver(receiverGPSLocationInfo, intentFilter);
            Toast.makeText(this, "注册成功", Toast.LENGTH_SHORT).show();

        } else
        {
            Toast.makeText(this, "重复注册", Toast.LENGTH_SHORT).show();
        }
    }

    //注销服务监听

    void UnRegister()
    {
        if (receiverGPSLocationInfo != null)
        {
            unregisterReceiver(receiverGPSLocationInfo);
            receiverGPSLocationInfo = null;
            Toast.makeText(this, "注销成功", Toast.LENGTH_SHORT).show();
        }

    }

    // /]

    // 检查服务是否正在运行
    <T> boolean CheckServiceIsRuning(Class<T> classT)
    {
        ActivityManager activityManager = (ActivityManager) getSystemService(ACTIVITY_SERVICE);
        List<RunningServiceInfo> runningServiceInfos = activityManager
                .getRunningServices(Integer.MAX_VALUE);
        if (runningServiceInfos != null)
        {
            for (RunningServiceInfo runningServiceInfo : runningServiceInfos)
            {
                if (runningServiceInfo.service.getClassName().equals(
                        classT.getName()))
                {

                    return true;
                }
            }

        }
        return false;
    }

}
