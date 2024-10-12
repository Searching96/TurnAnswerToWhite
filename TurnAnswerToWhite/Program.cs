using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"linktoyourdocxfile"; 
        ChangeCorrectAnswerColor(filePath);
    }

    static void ChangeCorrectAnswerColor(string filePath)
    {
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
        {
            Body body = wordDoc.MainDocumentPart.Document.Body;

            foreach (var paragraph in body.Elements<Paragraph>())
            {
                if (paragraph.InnerText.Contains("Đáp án đúng:"))
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        RunProperties runProperties = new RunProperties();
                        Color color = new Color() { Val = "FFFFFF" };
                        runProperties.Append(color);
                        run.PrependChild(runProperties);
                    }
                }
            }

            wordDoc.MainDocumentPart.Document.Save();
        }
    }
}
