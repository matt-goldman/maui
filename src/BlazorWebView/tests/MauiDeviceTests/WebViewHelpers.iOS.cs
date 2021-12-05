﻿using System;
using System.Threading;
using System.Threading.Tasks;
using WebKit;

namespace Microsoft.Maui.MauiBlazorWebView.DeviceTests
{
	public static class WebViewHelpers
	{
		public static async Task WaitForWebViewReady(WKWebView webview)
		{
			const int MaxWaitTimes = 10;
			const int WaitTimeInMS = 200;
			await Task.Delay(5000);

			for (int i = 0; i < MaxWaitTimes; i++)
			{
				var blazorObject = await ExecuteScriptAsync(webview, "(window.Blazor !== null).toString()");
				if (blazorObject == "true")
				{
					return;
				}
				await Task.Delay(WaitTimeInMS);
			}

			var blazorObject2 = await ExecuteScriptAsync(webview, "window.Blazor === null ? 'IT IS NULL' : window.Blazor.toString()");

			throw new Exception($"Waited {MaxWaitTimes * WaitTimeInMS}ms but couldn't get window.Blazor to be non-null. IsLoading={webview.IsLoading}, EstimatedProgress={webview.EstimatedProgress}, blazorObject2={blazorObject2}");
		}

		public static async Task<string> ExecuteScriptAsync(WKWebView webview, string script)
		{
			var nsStringResult = await webview.EvaluateJavaScriptAsync(script);
			return nsStringResult?.ToString();
		}

		public static async Task WaitForControlDiv(WKWebView webView, string controlValueToWaitFor)
		{
			const int MaxWaitTimes = 10;
			const int WaitTimeInMS = 200;
			var quotedExpectedValue = "\"" + controlValueToWaitFor + "\"";
			for (int i = 0; i < MaxWaitTimes; i++)
			{
				var controlValue = await ExecuteScriptAsync(webView, "document.getElementById('controlDiv').innerText");
				if (controlValue == quotedExpectedValue)
				{
					return;
				}
				await Task.Delay(WaitTimeInMS);
			}

			throw new Exception($"Waited {MaxWaitTimes * WaitTimeInMS}ms but couldn't get controlDiv to have value '{controlValueToWaitFor}'.");
		}
	}
}
