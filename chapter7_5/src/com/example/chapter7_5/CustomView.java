package com.example.chapter7_5;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;

public class CustomView extends View {

	Paint mPaint;
	List<Dot> dots;

	public CustomView(Context context) {
		super(context);
		init();
	}

	public CustomView(Context context, AttributeSet attrs) {
		super(context);
		init();
	}

	public void init() {
		mPaint = new Paint();
		mPaint.setColor(Color.RED);
		mPaint.setAntiAlias(true);
		setBackgroundColor(Color.BLUE);

		dots = new ArrayList<CustomView.Dot>();
	}

	@Override
	protected void onDraw(Canvas canvas) {
		// TODO Auto-generated method stub
	
		for(Dot dot:dots)
		{
			canvas.drawCircle(dot.x,dot.y, dot.radius, mPaint);
		}
	}

	@Override
	public boolean onTouchEvent(MotionEvent event) {
		// TODO Auto-generated method stub
		
		float x=event.getX();
		float y=event.getY();
		float radius=3;
		
		
		dots.add(new Dot(x, y, radius));
		invalidate();
		return super.onTouchEvent(event);
	}

	static class Dot {
		public float x;
		public float y;
		public float radius;

		public Dot(float x, float y, float radius) {
			this.x = x;
			this.y = y;
			this.radius = radius;
		}
	}

}
