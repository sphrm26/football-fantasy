namespace TestProject;

[TestClass]
public class emailTest
{
    [TestMethod]
    public void atsignCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail("sgv@hrm@gmail.com");
    }

    [TestMethod]
    public void noneAtsign()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail("sgvhrmgmail.com");
    }

    [TestMethod]
    public void dotCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail("f.ghb@gmail.com");
    }

    [TestMethod]
    public void startWithDot()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail(".ghb@gmail.com");
    }

    [TestMethod]
    public void endWithDot()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail("ghb.@gmail.com");
    }
    [TestMethod]
    public void domainCheck()
    {
        footballFantasy.BuisnessLayer.validaitonSignUp.validationEmail("ghb@gmail.co.m");
    }
}