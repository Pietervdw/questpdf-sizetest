using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace QuestPdfFileSizeTest
{
	class Program
	{
		static void Main(string[] args)
		{
			GenerateDoc(FontNames.NotoSans);
			GenerateDoc(FontNames.NotoSansSmall);
			GenerateDoc(FontNames.NotoSansSmall2);
			Console.WriteLine("========================================");
			GenerateDoc(FontNames.Calibri);
			GenerateDoc(FontNames.CalibriSmall);
			Console.WriteLine("========================================");
			GenerateDoc(FontNames.Tahoma);
			Console.WriteLine("========================================");
			GenerateDoc(FontNames.SegoeUI);
			Console.WriteLine("========================================");
			GenerateDoc(FontNames.Arial);

			Console.Read();
		}

		private static void GenerateDoc(string fontName)
		{
			string filePath = @$"C:\temp\questpdftest_{fontName}.pdf";
			var document = new TestDoc(fontName);
			document.GeneratePdf(filePath);
			Console.WriteLine($"{fontName} -> {new System.IO.FileInfo(filePath).Length / 1000} bytes");
		}
	}

	public static class FontNames
	{
		public static string NotoSans = "Noto Sans";
		public static string NotoSansSmall = "NotoSansSmall";
		public static string NotoSansSmall2 = "NotoSansSmall2";

		public static string Calibri = "Calibri";
		public static string CalibriSmall = "CalibriSmall";

		public static string Tahoma = Fonts.Tahoma;

		public static string SegoeUI = Fonts.SegoeUI;

		public static string Arial = Fonts.Arial;
	}
}
