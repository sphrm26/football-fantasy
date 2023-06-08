namespace TestProject;
[TestClass]
public class userNameTest
{
    [TestMethod]
    public void justNumberandLetter()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.usernameCorrectionCheck("sd43dJh↓ss");
    }
    [TestMethod]
    public void minLengthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.usernameCorrectionCheck("sdss");
    }
    [TestMethod]
    public void maxLengthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.usernameCorrectionCheck("aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeer");
    }

    [TestMethod]
    public void correctForm()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.usernameCorrectionCheck("fmkdld");
    }
}