using System;

public interface IDocument
{
    void Open();
}

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word document.");
}

public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF document.");
}

public class ExcelDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Excel document.");
}

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new WordDocument();
}

public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}

public class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new ExcelDocument();
}

public class FactoryPatternExample
{
    public static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        IDocument excel = excelFactory.CreateDocument();
        excel.Open();
    }
}