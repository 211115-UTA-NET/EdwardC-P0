using Project_0App.App;
using Xunit;

namespace Project_0App.Tests;

public class LoginTest
{
    [Fact]
    public void Test1()
    {
        // Arrange
        Login myLogin = new Login();
        myLogin.LoginScreen(MainProgram.Mode.Login);

        // Act

        // Assert
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var myLogin = new Login();

       
        
    }
}