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
    public void correctForm()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.passwordCorrectionCheck("dkfxDXK32");
    }
}