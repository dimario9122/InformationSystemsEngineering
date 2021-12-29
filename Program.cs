using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Mfc mfc = new Mfc();
            Reader reader = new Reader();
            reader.SeeDocuments(mfc);

            Console.Read();
        }
    }

    class Reader
    {
        public void SeeDocuments(Mfc mfc)
        {
            IDocumentIterator iterator = mfc.CreateNumerator();
            while (iterator.HasNext())
            {
                Document Document = iterator.Next();
                Document.Print();
            }
        }
    }

    interface IDocumentIterator
    {
        bool HasNext();
        Document Next();
    }
    interface IDocumentNumerable
    {
        IDocumentIterator CreateNumerator();
        int Count { get; }
        Document this[int index] { get; }
    }
    class Document
    {
        public Doc Doc { get; set; }
        public Series Series { get; set; }
        public Numbers Numbers { get; set; }
        public void Print()
        {
            Console.WriteLine("Наименование документа: "+this.Doc.Name + "\n" + "Серия: " +this.Series.Serie + "\n" + "Номер документа: " +Convert.ToString(this.Numbers.Number) + "\n");
        }
    }
    class Doc
    {
        public string Name { get; set; }
    }
    class Series
    {
        public string Serie { get; set; }
    }
    class Numbers
    {
        public int Number { get; set; }
    }
    abstract class DocumentBuilder
    {
        public Document Document { get; private set; }
        public void CreateDocument()
        {
            Document = new Document();
        }
        public abstract void SetDoc();
        public abstract void SetSeries();
        public abstract void Setnumber();
    }
    class MakeDocument
    {
        public Document Create(DocumentBuilder DocumentBuilder)
        {
            DocumentBuilder.CreateDocument();
            DocumentBuilder.SetDoc();
            DocumentBuilder.SetSeries();
            DocumentBuilder.Setnumber();
            return DocumentBuilder.Document;
        }
    }
    class PassportBuilder : DocumentBuilder
    {
        public override void SetDoc()
        {
            this.Document.Doc = new Doc { Name = "Паспорт" };
        }
        public override void SetSeries()
        {
            this.Document.Series = new Series { Serie = "4252" };
        }
        public override void Setnumber()
        {
            this.Document.Numbers = new Numbers { Number = 445727 };
        }
    }
    class INNBuilder : DocumentBuilder
    {
        public override void SetDoc()
        {
            this.Document.Doc = new Doc { Name = "ИНН" };
        }
        public override void SetSeries()
        {
            this.Document.Series = new Series { Serie = "" };
        }
        public override void Setnumber()
        {
            this.Document.Numbers = new Numbers { Number = 1234562662 };
        }
    }
    class SNILSBuilder : DocumentBuilder
    {
        public override void SetDoc()
        {
            this.Document.Doc = new Doc { Name = "СНИЛС" };
        }
        public override void SetSeries()
        {
            this.Document.Series = new Series { Serie = "123-642-643-06" };
        }
        public override void Setnumber()
        {
            this.Document.Numbers = new Numbers { Number = 0 };
        }
    }
    class Mfc : IDocumentNumerable
    {
        private MakeDocument maker0 = new MakeDocument();
        private DocumentBuilder Document0 = new PassportBuilder();
        private MakeDocument maker1 = new MakeDocument();
        private DocumentBuilder Document1 = new INNBuilder();
        private MakeDocument maker2 = new MakeDocument();
        private DocumentBuilder Document2 = new SNILSBuilder();
        private Document[] Documents;
        public Mfc()
        {
            Documents = new Document[]
            {
                 maker0.Create(Document0),
                 maker1.Create(Document1),
                 maker2.Create(Document2)
            };
        }
        public int Count
        {
            get { return Documents.Length; }
        }

        public Document this[int index]
        {
            get { return Documents[index]; }
        }
        public IDocumentIterator CreateNumerator()
        {
            return new MfcNumerator(this);
        }
    }
    class MfcNumerator : IDocumentIterator
    {
        IDocumentNumerable aggregate;
        int index = 0;
        public MfcNumerator(IDocumentNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Document Next()
        {
            return aggregate[index++];
        }
    }
}