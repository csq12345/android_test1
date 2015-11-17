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

        String sss = intent.getStringExtra("gpsbundle");
        if (sss != null)
        {
            Log.d("ReceiverGPS", sss);
        }

        if (uiHandler != null)
        {

            Message msg = uiHandler.obtainMessage();
            Bundle bb = new Bundle();
            if (sss != null)
            {
                bb.putString("str", sss);
            }
            bb.putString("timecount", s1);
            msg.setData(bb);
            uiHandler.sendMessage(msg);
        }


    }

}
