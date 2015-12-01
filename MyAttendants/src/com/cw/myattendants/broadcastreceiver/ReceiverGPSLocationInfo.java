package com.cw.myattendants.broadcastreceiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

public class ReceiverGPSLocationInfo extends BroadcastReceiver
{
    Handler uiHandler;

    //传入一个句柄
    public ReceiverGPSLocationInfo(Handler uIHandler)
    {
        uiHandler = uIHandler;
    }

    @Override
    public void onReceive(Context context, Intent intent)
    {
        // TODO Auto-generated method stub
        String s1 = intent.getStringExtra("timecount");

        String gpsstr = intent.getStringExtra("gpsbundle");
        if (gpsstr != null)
        {
            Log.d("ReceiverGPS", gpsstr);
        }

        if (uiHandler != null)
        {


            Log.d("ReceiverGPS", "接收到广播");
            Message msg = uiHandler.obtainMessage();
            Bundle bb = new Bundle();
            if (gpsstr != null)
            {
                bb.putString("gpsstr1", gpsstr);
            }
            bb.putString("timecount1", s1);
            msg.setData(bb);
            uiHandler.sendMessage(msg);
            Log.d("ReceiverGPS", "发送消息完成");


        }


    }


    public void UnRegidit()
    {
        uiHandler = null;
    }
}
