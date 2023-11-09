using System.Net;
using WebProject.Handler;

public class RegisterHandler : Handler
{
    public override void HandleRequest(HttpListenerContext context)
    {
        if (context.Request.HttpMethod == "GET" && context.Request.Url.LocalPath == "/register")
        {
            // Отправить страницу регистрации клиенту
            // В этом месте вы можете отправить HTML-страницу для регистрации, например, содержимое файла register.html
        }
        else if (Successor != null)
        {
            Successor.HandleRequest(context);
        }
    }
}

public class LoginHandler : Handler
{
    public override void HandleRequest(HttpListenerContext context)
    {
        if (context.Request.HttpMethod == "GET" && context.Request.Url.LocalPath == "/login")
        {
            // Отправить страницу входа клиенту
            // В этом месте вы можете отправить HTML-страницу для входа, например, содержимое файла login.html
        }
        else if (Successor != null)
        {
            Successor.HandleRequest(context);
        }
    }
}