package com.example.paad_compass;

import android.R.integer;
import android.content.Context;
import android.content.res.Resources;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.View;
import android.view.accessibility.AccessibilityEvent;

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

	// /[ InitcompassView

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

		Resources r = this.getResources();

		circlePaint = new Paint(Paint.ANTI_ALIAS_FLAG);
		circlePaint.setColor(r.getColor(R.color.background_color));
		circlePaint.setStrokeWidth(1);
		circlePaint.setStyle(Paint.Style.FILL_AND_STROKE);

		northString = r.getString(R.string.cardinal_north);
		eastString = r.getString(R.string.cardinal_east);
		southString = r.getString(R.string.cardinal_south);
		westString = r.getString(R.string.cardinal_west);

		textPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
		textPaint.setColor(r.getColor(R.color.text_color));

		textHeight = (int) textPaint.measureText("yY");

		markerPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
		markerPaint.setColor(r.getColor(R.color.marker_color));

	}

	// /]
	@Override
	protected void onMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		int measuredWidth = Measure(widthMeasureSpec);
		int measuredHeight = Measure(heightMeasureSpec);

		int d = Math.min(measuredWidth, measuredHeight);

		setMeasuredDimension(measuredWidth, measuredHeight);

		// super.onMeasure(widthMeasureSpec, heightMeasureSpec);
	}

	String angle = "=";

	@Override
	protected void onDraw(Canvas canvas)
	{
		int mMeasuredWidth = getMeasuredWidth();
		int mMeasuredHeight = getMeasuredHeight();

		int px = mMeasuredWidth / 2;
		int py = mMeasuredHeight / 2;

		int radius = Math.min(px, py);

		canvas.drawCircle(px, py, radius, circlePaint);
		canvas.save();
		canvas.rotate(-bearing, px, py);

		int textWidth = (int) textPaint.measureText("W");

		int cardinalX = px - textWidth / 2;
		int cardinalY = py - radius + textHeight;

		for (int i = 0; i < 24; i++)
		{
			canvas.drawLine(px, py - radius, px, py - radius + 10, markerPaint);

			canvas.save();

			canvas.translate(0, textWidth);

			if (i % 6 == 0)
			{
				String dirString = "";
				switch (i)
				{
					case 0:
					{
						dirString = northString;
						int arrowY = 2 * textHeight;
						canvas.drawLine(px, arrowY, px - 5, 3 * textHeight,
								markerPaint);
						canvas.drawLine(px, arrowY, px + 5, 3 * textHeight,
								markerPaint);
					}
						break;
					case 6:
						dirString = eastString;
						break;
					case 12:
						dirString = southString;
						break;
					case 18:
						dirString = westString;
						break;
					default:
						break;
				}
			} else if (i % 3 == 0)
			{
				String angleString = String.valueOf(i * 15);
				float angleTextWidth = textPaint.measureText(angle);

				int angleTextX = (int) (px - angleTextWidth / 2);
				int angleTextY = py - radius + textHeight;

				canvas.drawText(angleString, angleTextX, angleTextY, textPaint);
			}

			canvas.restore();
			canvas.rotate(15, px, py);
		}
		canvas.restore();

		// super.onDraw(canvas);
	}

	@Override
	public boolean dispatchPopulateAccessibilityEvent(AccessibilityEvent event)
	{

		// return super.dispatchPopulateAccessibilityEvent(event);

		if (isShown())
		{
			String bearingStr = String.valueOf(bearing);
			if (bearingStr.length() > AccessibilityEvent.MAX_TEXT_LENGTH)
			{
				bearingStr = bearingStr.substring(0,
						AccessibilityEvent.MAX_TEXT_LENGTH);
			}
			event.getText().add(bearingStr);
			return true;

		} else
		{
			return false;
		}
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

	// /[  Ù–‘
	float bearing;

	public float getBearing()
	{
		return bearing;
	}

	public void setBearing(float bearing)
	{
		this.bearing = bearing;
		sendAccessibilityEvent(AccessibilityEvent.TYPE_VIEW_TEXT_CHANGED);
	}

	// /]
}
