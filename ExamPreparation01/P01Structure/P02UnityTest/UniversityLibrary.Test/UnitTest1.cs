namespace UniversityLibrary.Test
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private TextBook textBook;
        private string title = "1998";
        private string author = "Ivan";
        private string category = "Finance";

        private UniversityLibrary lib;
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title, author, category);
            lib = new UniversityLibrary();
        }
        [TearDown]
        public void TearDown()
        {
            textBook = null;
            lib = null;
        }
        [Test]
        public void TestTextBookConstuctor()
        {
            textBook = new TextBook(title, author, category);
            Assert.That(textBook.Title, Is.EqualTo(title));
            Assert.That(textBook.Author, Is.EqualTo(author));
            Assert.That(textBook.Category, Is.EqualTo(category));
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {title} - 0");
            sb.AppendLine($"Category: {category}");
            sb.AppendLine($"Author: {author}");
            string result = sb.ToString().TrimEnd();
            Assert.That(result, Is.EqualTo(textBook.ToString()));
        }
        [Test]
        public void TestUnivestityLyberyCtor()
        {
            lib = new UniversityLibrary();

            Assert.That(0, Is.EqualTo(lib.Catalogue.Count));
        }

        [Test]
        public void AddTextBookWorks()
        {
            string result = lib.AddTextBookToLibrary(textBook);

            Assert.AreEqual(textBook.InventoryNumber, 1);
            Assert.AreEqual(textBook.Title, title);
            Assert.AreEqual(lib.Catalogue.Count, 1);
            Assert.AreEqual(lib.Catalogue[0].Title, title);
        }

        [Test]
        public void Loan()
        {
            lib.AddTextBookToLibrary(textBook);

            string result = lib.LoanTextBook(1, "Pesho");

            Assert.AreEqual(textBook.Holder, "Pesho");
            Assert.AreEqual(result, $"{title} loaned to {"Pesho"}.");

            string result2 = lib.LoanTextBook(1, "Pesho");
            Assert.AreEqual(result2, $"{"Pesho"} still hasn't returned {title}!");
        }

        [Test]
        public void Return()
        {
            lib.AddTextBookToLibrary(textBook);
            lib.LoanTextBook(1, "Pesho");
            string result = lib.ReturnTextBook(textBook.InventoryNumber);

            Assert.AreEqual(result, $"{title} is returned to the library.");
            Assert.AreEqual(textBook.Holder, "");


        }
        [Test]
        public void AddMoreTextBook()
        {
            for (int i = 0; i < 10; i++)
            {
                lib.AddTextBookToLibrary(textBook);
            }
            Assert.AreEqual(lib.Catalogue.Count, 10);
        }

        [Test]
        public void ReturnAndLoanNotFound()
        {
            Assert.Throws<NullReferenceException>(() => lib.LoanTextBook(55, "Test"));
            Assert.Throws<NullReferenceException>(() => lib.ReturnTextBook(55));
        }
    }
}