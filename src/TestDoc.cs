
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPdfFileSizeTest
{
	public class TestDoc : IDocument
	{
		
		private readonly string _fontName;

		public TestDoc(string fontName)
		{
			this._fontName = fontName;
		}

		public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

		public void Compose(IDocumentContainer container)
		{
			container
				.Page(page =>
				{
					page.Margin(50);
					page.Content().Element(ComposeContent);
				});
		}

		void ComposeContent(IContainer container)
		{
			container.Row(row =>
			{
				row.RelativeItem().Column(stack =>
				{
					stack.Item().Text(Faker.Lorem.Sentence(10), TextStyle.Default.FontType(_fontName).Size(18));
					stack.Item().Text("$$ 1 2 3 4 5 6 7 8 9 0 - + < > / | ? [ ] { } %", TextStyle.Default.FontType(_fontName).Size(18));
					stack.Item().Text(Faker.Lorem.Sentence(10), TextStyle.Default.FontType(_fontName).Size(16));
					stack.Item().Text("$$ 1 2 3 4 5 6 7 8 9 0 - + < > / | ? [ ] { } %", TextStyle.Default.FontType(_fontName).Size(16));

					for (int i = 0; i < 85; i++)
					{
						stack.Item().Text(Faker.Lorem.Sentence(10), TextStyle.Default.FontType(_fontName).Size(16));
					}

					stack.Item().PageBreak();
					stack.Item().Element(ComposeTable);
				});

			});
		}

		void ComposeTable(IContainer container)
		{
			var headerStyle = TextStyle.Default.FontType(_fontName).Size(16);
			var bodyTextStyle = TextStyle.Default.FontType(_fontName).Size(16);

			
			container.Table(table =>
			{
				table.ColumnsDefinition(columns =>
				{
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.RelativeColumn();
				});

				table.Header(header =>
				{
					header.Cell().Text("#", headerStyle);
					header.Cell().Text("First Name", headerStyle);
					header.Cell().Text("Last Name", headerStyle);
				});

				for (int i = 1; i <= 510; i++)
				{
					table.Cell().Element(CellStyle).Text(i, bodyTextStyle);
					table.Cell().Element(CellStyle).Text(Faker.Name.First(), bodyTextStyle);
					table.Cell().Element(CellStyle).Text(Faker.Name.Last(), bodyTextStyle);

					static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
				}
			});
		}
	}
}

