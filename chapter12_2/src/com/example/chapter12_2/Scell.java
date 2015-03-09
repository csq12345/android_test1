package com.example.chapter12_2;

import android.R.integer;

public class Scell
{
int MCC=0;//国家码
int MNC=0;//移动网络码 00移动 01联通
int LAC=0;//位置区域码
int CID=0;//基站编号
public int getMCC()
{
	return MCC;
}
public void setMCC(int mCC)
{
	MCC = mCC;
}
public int getMNC()
{
	return MNC;
}
public void setMNC(int mNC)
{
	MNC = mNC;
}
public int getLAC()
{
	return LAC;
}
public void setLAC(int lAC)
{
	LAC = lAC;
}
public int getCID()
{
	return CID;
}
public void setCID(int cID)
{
	CID = cID;
}




}
