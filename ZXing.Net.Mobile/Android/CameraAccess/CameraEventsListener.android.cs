using System;
using Android.Hardware;

namespace ZXing.Mobile.CameraAccess
{
	public class CameraEventsListener : Java.Lang.Object, Camera.IPreviewCallback, Camera.IAutoFocusCallback
	{
		public event EventHandler<byte[]> OnPreviewFrameReady;

		public void OnPreviewFrame(byte[] data, Camera camera)
		{
			if (data != null && data.Length > 0)
			{
				OnPreviewFrameReady?.Invoke(this, data);

				camera.AddCallbackBuffer(data);
			}
		}

		public void OnAutoFocus(bool success, Camera camera)
		{
			Android.Util.Log.Debug(MobileBarcodeScanner.TAG, "AutoFocus {0}", success ? "Succeeded" : "Failed");
		}
	}
}
