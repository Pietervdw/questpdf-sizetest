# Creating smaller sized PDF files using QuestPDF
This is a very simple sample console app written in C# that illustrates how you can use a subsets of fonts to generate smaller sized PDF's using [QuestPDF](https://github.com/QuestPDF/QuestPDF)

This is based on an [issue 31](https://github.com/QuestPDF/QuestPDF/issues/31) in the QuestPDF GitHub repo.

This repo contains 2 font subsets, created with the steps mentioned below. The resulting PDF is 30 pages and it's size, using different fonts are:
| Font           | Approx. File Size (bytes) |
| -------------- | ------------------------- |
| Noto Sans      | 267                       |
| NotoSansSmall  | 93                        |
| NotoSansSmall2 | 65                        |
| Calibri        | 824                       |
| CalibriSmall   | 83                        |
| Tahoma         | 564                       |
| Segoe UI       | 595                       |
| Arial          | 590                       |

## Steps on how to create a subset of your font:

1.  Go to [https://everythingfonts.com/subsetter](https://everythingfonts.com/subsetter) (There is a cost involved if you want to convert large fonts)
2. Upload the file & select the following options:
	a) Basic Latin
	b) Uppercase
	c) Lowercase
	d) Numerals
	e) Basic Punctuation
	f) Currency Symbols
3. Generate and download the created file
4. Use [FontForge](https://fontforge.org/en-US/). File > Open & open the created subset font file
5. Select Element Menu > Font Info
6. Create a new name for the font in the following fields e.g CalibriSmall
	a) Fontname
	b) Family Name
	c) Name for Humans
7. Click Ok. When prompted, overwrite the GUID for the font.
8. File Menu > Generate Fonts
	a) Set Type to TrueType
	b) Click Generate

Install the newly created font on your system and in you code use the font name **CalibriSmall**
