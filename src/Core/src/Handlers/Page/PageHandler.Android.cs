﻿namespace Microsoft.Maui.Handlers
{
	public partial class PageHandler : ContentViewHandler
	{
		public static void MapTitle(PageHandler handler, IContentView page)
		{
		}

		public static void MapBackgroundImageSource(PageHandler handler, IPage page)
		{
			var provider = handler.GetRequiredService<IImageSourceServiceProvider>();

			handler.NativeView?.UpdateBackgroundImageSourceAsync(page, provider)	
				.FireAndForget(handler);
		}
	}
}
