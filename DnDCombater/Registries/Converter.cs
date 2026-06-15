using System.IO;
using System.Windows.Media.Imaging;

namespace DnDCombater.Registries
{
	public static class Converter
	{
		public static BitmapImage? ConvertToImage(byte[]? data)
		{
			if (data == null || data.Length == 0)
				return null;

			using var ms = new MemoryStream(data);

			var image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = ms;
			image.CacheOption = BitmapCacheOption.OnLoad;
			image.EndInit();
			image.Freeze();

			return image;
		}

		public static byte[]? ConvertToBytes(BitmapImage? image)
		{
			if (image == null)
				return null;

			using var ms = new MemoryStream();

			BitmapEncoder encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			encoder.Save(ms);

			return ms.ToArray();

		}
	}
}
