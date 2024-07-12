namespace ImageGenerator {
	using System.IO;
	using SkiaSharp;


/***/
public class ImageGenerator {

	private static int imageWidth = 1000;
	private Random random;

	private ulong folderNo = 0;
	private ulong imageNo = 0;


	/***/
	public static void Main(string[] args) {
		if(args.Length > 0 && args[0].Equals("all")) {
			new ImageGenerator(true);
		}
		else if(args.Length > 0 && args[0].Equals("test")) {
			new ImageGenerator(false);
		}
		else {
			Console.WriteLine("Run with a parameter 'all' to create all images or with 'test' to create 10 test images.");
		}
    }


	/***/
	public ImageGenerator(bool createAll) {
		random = new Random();

		if(createAll) {
			while(true) {
				createImage();
			}
		}
		else {
			for(int i = 0; i < 10; i++) {
				createImage();
			}
		}
	}


	/***/
	private void createImage() {
		SKBitmap bitmap = new SKBitmap(imageWidth, imageWidth);
    	using SKCanvas canvas = new SKCanvas(bitmap);
    	
		SKPoint point = new SKPoint();
		byte[] rgb = new byte[3];

		for(int i = 0; i < imageWidth; i++) {
			for(int j = 0; j < imageWidth; j++) {
				point.X = i;
				point.Y = j;

				random.NextBytes(rgb);
				SKColor color = new SKColor(rgb[0], rgb[1], rgb[2]);

				canvas.DrawPoint(point, color);
			}
		}

		Directory.CreateDirectory("" + folderNo);
		string imageName = folderNo + "/" + imageNo + ".png";
		imageNo++;

		if(imageNo == ulong.MaxValue) {
			folderNo++;
			imageNo = 0;
		}

		using FileStream fileStream = new FileStream(imageName, FileMode.Create, FileAccess.Write);
    	using SKImage image = SKImage.FromBitmap(bitmap); 
    	using SKData data = image.Encode(); 
    	data.SaveTo(fileStream);
	}
}}