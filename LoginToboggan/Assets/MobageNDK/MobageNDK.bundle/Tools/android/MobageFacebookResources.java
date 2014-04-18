/**
 * Copyright 2013-present DeNA Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * This file has been added by DeNA Co., Ltd.
 */

package com.facebook;

import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

import android.content.Context;
import android.content.res.Resources;
import android.util.Log;

public final class MobageFacebookResources {

	private static Resources _resources = null;
	private static Context context = null;
	private static String sClassName = "com.mobage.global.android.Mobage";
	private static String TAG = "MobageFacebookResources";
	
	public static final void setContext(Context setContext) {
		context = setContext;
	}
			
	public static final Context getContext() {
		if (context == null)
		{
			try {
				Class<?> mobageClass = Class.forName(sClassName);
				String applicationContextMethod = "getApplicationContext";
				Method method = mobageClass.getMethod(applicationContextMethod, (Class<?>[]) null);
				Log.e(TAG, "getApplicationContext: " + method.getName());
				context = (Context) method.invoke(null, (Object[])null);
				if (context != null) {
					Log.e(TAG, context.toString());
				} else {
					Log.e(TAG, "Context null");
				}
			} catch (Exception e) {
				Log.e(TAG,"EXCEPTION getContext", e);
			}
		}
		return context;
	}
	
	private static final Resources resources() {
		getContext();
		if (_resources == null) {
			_resources = context.getResources();
		}
		return _resources;
	}

	private static String _packageName = null;
	private static final String packageName() {
		getContext();
		if (_packageName == null) {
			_packageName = context.getPackageName();
		}
		return _packageName;
	}

	private static final int identifier(String name, String type) {
		getContext();
		return resources().getIdentifier(name, type, packageName());
	}

	public static final int string(String name) {
		getContext();
		return identifier(name, "string");
	}

	public static final int bool(String name) {
		getContext();
		return identifier(name, "bool");
	}

	public static final int drawable(String name) {
		getContext();
		return identifier(name, "drawable");
	}

	public static final int id(String name) {
		getContext();
		return identifier(name, "id");
	}

	public static final int layout(String name) {
		getContext();
		return identifier(name, "layout");
	}
	
	public static final int[] convertToArray(int value) {
		return new int [] {value};
	}
	
	public static final int styleable(String name) {
		getContext();
		return identifier(name, "attr");
	}
	
	public static final int dimen(String name) {
		getContext();
		return identifier(name, "styles");
	}

	public static final int color(String name) {
		getContext();
		return identifier(name, "styles");
	}


	public static final int menu(String name) {
		getContext();
		return identifier(name, "menu");
	}

	public static final int style(String name) {
		getContext();
		return identifier(name, "style");
	}
}
