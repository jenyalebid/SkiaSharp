﻿using System;

namespace SkiaSharp
{
	public unsafe class SKPictureRecorder : SKObject, ISKSkipObjectRegistration
	{
		public SKPictureRecorder ()
			: base (SkiaApi.sk_picture_recorder_new ())
		{
		}

		protected override void Dispose (bool disposing) =>
			base.Dispose (disposing);

		protected override void DisposeNative () =>
			SkiaApi.sk_picture_recorder_delete (Handle);

		public SKCanvas BeginRecording (SKRect cullRect)
		{
			return OwnedBy (SKCanvas.GetObject (SkiaApi.sk_picture_recorder_begin_recording (Handle, &cullRect), false), this);
		}

		public SKPicture EndRecording ()
		{
			return SKPicture.GetObject (SkiaApi.sk_picture_recorder_end_recording (Handle));
		}

		public SKDrawable EndRecordingAsDrawable ()
		{
			return SKDrawable.GetObject (SkiaApi.sk_picture_recorder_end_recording_as_drawable (Handle));
		}

		public SKCanvas RecordingCanvas =>
			OwnedBy (SKCanvas.GetObject (SkiaApi.sk_picture_get_recording_canvas (Handle), false), this);
	}
}
