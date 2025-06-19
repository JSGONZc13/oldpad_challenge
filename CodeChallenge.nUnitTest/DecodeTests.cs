namespace CodeChallenge.nUnitTest
{
    public class DecodeTests
    {
        private Decode _decode { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            _decode = new Decode();
        }

        [TestCase("33#")]
        public void DecodedMessage_E_Test(String input)
        {
            // Assign
            //String input = "33#";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("E"));
        }

        [TestCase("227*#")]
        public void DecodedMessage_B_Test(String input)
        {
            // Assign
            //String input = "227*#";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [TestCase("4433555 555666#")]
        public void DecodedMessage_HELLO_Test(String input)
        {
            // Assign
            //String input = "4433555 555666#";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("HELLO"));
        }

        [TestCase("8 88777444666*664#")]
        public void DecodedMessage_TURING_Test(String input)
        {
            // Assign
            //String input = "8 88777444666*664#";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("TURING"));
        }

        [TestCase("")]
        public void DecodedMessage_INVALIDCODE_Test(String input)
        {
            // Assign
            //String input = "";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("ERROR: EMPTY CODE"));
        }

        [TestCase("A#")]
        public void DecodedMessage_INVALIDCHARS_Test(String input)
        {
            // Assign
            //String input = "A#";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("ERROR: CHECK CHARACTERS"));
        }

        [TestCase("2")]
        public void DecodedMessage_MISSINGENTER_Test(String input)
        {
            // Assign
            //String input = "2";

            //Act
            String result = _decode.DecodedMessage(input);

            //Assert
            Assert.That(result, Is.EqualTo("ERROR: MISSING #"));
        }
    }
}