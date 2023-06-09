namespace TestProject;
[TestClass]
public class nameTest
{
    [TestMethod]
    public void emptyNameCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationName("");
    }
    [TestMethod]
    public void maxLengthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationName("aaaaaaaaaabbbbbbbbbbccccccccccl");
    }

    [TestMethod]
    public void correctForm()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationName("dfxo☺3");
    }
}