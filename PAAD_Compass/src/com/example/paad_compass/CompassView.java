package com.example.paad_compass;

import android.R.integer;
import android.content.Context;
import android.content.res.Resources;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.View;

public class CompassView extends View
{

	
	
	public CompassView(Context context)
	{
		super(context);
		InitcompassView();
	}

	public CompassView(Context context, AttributeSet attrs)
	{
		super(context);
		InitcompassView();
	}

	public CompassView(Context context, AttributeSet attrs, int defaultStyle)
	{
		super(context);
		InitcompassView();
	}
///[ InitcompassView
	
	Paint markerPaint;
	Paint textPaint;
	Paint circlePaint;
	String northString;
	String eastString;
	String southString;
	String westString;
	int textHeight;
	
	void InitcompassView()
	{
		setFocusable(true);
		
		
		Resources r=this.getResources();
		
		
		circlePaint=new Paint(Paint.ANTI_ALIAS_FLAG);
		circlePaint.setColor(r.getColor(R.color.background_color));
		circlePaint.setStrokeWidth(1);
		circlePaint.setStyle(Paint.Style.FILL_AND_STROKE);
		
		 northString=r.getString(R.string.cardinal_north);
		 eastString=r.getString(R.string.cardinal_east);
		 southString=r.getString(R.string.cardinal_south);
		 westString=r.getString(R.string.cardinal_west);
		 
		 
		 
		
	}
///]
	@Override
	protected void onMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		int measuredWidth = Measure(widthMeasureSpec);
		int measuredHeight = Measure(heightMeasureSpec);

		int d=Math.min(measuredWidth, measuredHeight);
		
		setMeasuredDimension(measuredWidth, measuredHeight);
		
		//super.onMeasure(widthMeasureSpec, heightMeasureSpec);
	}

	int Measure(int measureSpec)
	{

		int result = 0;

		int specMode = MeasureSpec.getMode(measureSpec);
		int specSize = MeasureSpec.getSize(measureSpec);

		if (specMode == MeasureSpec.UNSPECIFIED)
		{
			result = 200;
		} else
		{
			result = specSize;
		}

		return result;
	}

	///[  Ù–‘
	float bearing;
	
	
	
	public float getBearing()
	{
		return bearing;
	}

	public void setBearing(float bearing)
	{
		this.bearing = bearing;
	}

	///]
}
