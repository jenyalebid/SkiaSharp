﻿using System;

namespace SkiaSharp
{
	public class SKFontStyle : SKObject, ISKSkipObjectRegistration
	{
		private static readonly SKFontStyle normal;
		private static readonly SKFontStyle bold;
		private static readonly SKFontStyle italic;
		private static readonly SKFontStyle boldItalic;

		static SKFontStyle ()
		{
			normal = new SKFontStyleStatic (SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
			bold = new SKFontStyleStatic (SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
			italic = new SKFontStyleStatic (SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic);
			boldItalic = new SKFontStyleStatic (SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic);
		}

		private SKFontStyle (IntPtr handle)
			: base (handle)
		{
		}

		public SKFontStyle ()
			: this (SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
		{
		}

		public SKFontStyle (SKFontStyleWeight weight, SKFontStyleWidth width, SKFontStyleSlant slant)
			: this ((int)weight, (int)width, slant)
		{
		}

		public SKFontStyle (int weight, int width, SKFontStyleSlant slant)
			: base (SkiaApi.sk_fontstyle_new (weight, width, slant))
		{
		}

		protected override void Dispose (bool disposing) =>
			base.Dispose (disposing);

		protected override void DisposeNative () =>
			SkiaApi.sk_fontstyle_delete (Handle);

		public int Weight => SkiaApi.sk_fontstyle_get_weight (Handle);

		public int Width => SkiaApi.sk_fontstyle_get_width (Handle);

		public SKFontStyleSlant Slant => SkiaApi.sk_fontstyle_get_slant (Handle);

		public static SKFontStyle Normal => normal;

		public static SKFontStyle Bold => bold;

		public static SKFontStyle Italic => italic;

		public static SKFontStyle BoldItalic => boldItalic;

		internal static SKFontStyle Create (SKTypeface typeface)
		{
			if (typeface == null)
				throw new ArgumentNullException (nameof (typeface));

			return GetObject (SkiaApi.sk_typeface_get_fontstyle (typeface.Handle));
		}

		//

		internal static SKFontStyle GetObject (IntPtr handle) =>
			handle == IntPtr.Zero ? null : new SKFontStyle (handle);

		//

		private sealed class SKFontStyleStatic : SKFontStyle
		{
			internal SKFontStyleStatic (SKFontStyleWeight weight, SKFontStyleWidth width, SKFontStyleSlant slant)
				: base (weight, width, slant)
			{
				IgnorePublicDispose = true;
			}
		}
	}
}
