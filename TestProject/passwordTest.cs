namespace TestProject;

[TestClass]
public class passwordTest
{
    [TestMethod]
    public void minlengthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("jklkdbd");
    }

    [TestMethod]
    public void maxlengthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("aaaaabbbbbcccccdddddeeeeefffffv");
    }
    [TestMethod]
    public void minlendgthCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("DKC5FKk");
    }
    [TestMethod]
    public void uncorrectSymboleChck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("dkf☺DXK32");
    }
    [TestMethod]
    public void spaceCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("dkfxD XK32");
    }
    [TestMethod]
    public void symboleCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("dD3@#$%^&*+=_!");
    }
    [TestMethod]
    public void correctForm()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("dkfxDXK32");
    }
}