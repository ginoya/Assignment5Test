using Assignment5;

namespace Assignment5Test
{
    public class ConsoleReaderTest
    {
        static bool onWordMockCalled = false;
        static bool onNumberCalled = false;
        static bool onJunkCalled = false;
        [Fact]
        public void ConsoleReaderTestForWord()
        {
            string inputToMock = "WordInput";

            StringReader stringReader = new StringReader(inputToMock);

            Console.SetIn(stringReader);
          
            ConsoleReader.readFromConsole(OnWordMock, OnNumberMock, OnJunkMock);

            Assert.True(onWordMockCalled);

            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ConsoleReaderTestForNumber()
        {
            string inputToMock = "123";

            StringReader stringReader = new StringReader(inputToMock);

            Console.SetIn(stringReader);

            ConsoleReader.readFromConsole(OnWordMock, OnNumberMock, OnJunkMock);

            Assert.True(onNumberCalled);

            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [Fact]
        public void ConsoleReaderTestForJunk()
        {
            string inputToMock = "123Abc";

            StringReader stringReader = new StringReader(inputToMock);

            Console.SetIn(stringReader);

            ConsoleReader.readFromConsole(OnWordMock, OnNumberMock, OnJunkMock);

            Assert.True(onJunkCalled);

            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        public static void OnJunkMock(string junk)
        {
            onJunkCalled = true;
            Console.WriteLine("OnJunk called! as user input string is : {0}", junk);
        }

        public static void OnWordMock(string word)
        {
            onWordMockCalled = true;
            Console.WriteLine("OnWord called! as user input string is : {0}", word);
        }

        public static void OnNumberMock(int number)
        {
            onNumberCalled = true;
            Console.WriteLine("OnNumber called! as user input string is : {0}", number);
        }
    }
}