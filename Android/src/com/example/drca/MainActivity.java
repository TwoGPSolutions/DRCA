package com.example.drca;

import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.view.Menu;
import android.view.View;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.EditText;
import android.widget.Toast;

@SuppressLint("SetJavaScriptEnabled")
public class MainActivity extends Activity {
	WebView Wv;
	EditText Pak;
	String uri;
	WifiManager wifi;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		wifi=(WifiManager)getSystemService(Context.WIFI_SERVICE);
		
		wifi.setWifiEnabled(true);

		Wv = (WebView)findViewById(R.id.webView1);
		Pak = (EditText)findViewById(R.id.editText1);
		LoadURL("http://192.168.137.1/dropbox/");
	}
	public void LoadURL(String URL){
		Wv.getSettings().setJavaScriptEnabled(true);
		Wv.setWebViewClient(new WebViewClient() {
			public boolean shouldOverrideUrlLoading(WebView view, String url){
				view.loadUrl(url);
				return true;
				}
			public void onReceivedError(WebView view, int errorCod,String description, String failingUrl) {
				wifi.setWifiEnabled(false);
	        }
		});
		Wv.loadUrl(URL);
	}

	public void SendPacket(View v){
		String msg=Pak.getText().toString();
		if(msg != "")
			LoadURL("http://192.168.137.1/dropbox/?msg=" + msg);
		Pak.setText("");
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}
