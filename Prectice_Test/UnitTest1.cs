using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Prectice_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var capturedStdOut = CapturedStdOut(() =>
            {
                RunApp(arguments: new string[] { "argument1", "argument2" });
            });

            Assert.AreEqual("Passing two arguments is not supported.", capturedStdOut);
        }

        void RunApp(string[]? arguments = default)
        {
            var entryPoint = typeof(Program).Assembly.EntryPoint!;
            entryPoint.Invoke(null, new object[] { arguments ?? Array.Empty<string>() });
        }

        string CapturedStdOut(Action callback)
        {
            TextWriter originalStdOut = Console.Out;

            using var newStdOut = new StringWriter();
            Console.SetOut(newStdOut);

            callback.Invoke();
            var capturedOutput = newStdOut.ToString();

            Console.SetOut(originalStdOut);

            return capturedOutput;
        }
    }
}
