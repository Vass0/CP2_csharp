using Microsoft.AspNetCore.Mvc;

namespace Prova.Api.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = @"
                <html>
                    <head>
                        <title>Prova .NET API</title>
                        <style>
                            body {
                                display: flex;
                                justify-content: center;
                                align-items: center;
                                height: 100vh;
                                background-color: #f4f4f9;
                                font-family: Arial, sans-serif;
                            }
                            .container {
                                text-align: center;
                            }
                            h1 {
                                color: #333;
                                margin-bottom: 20px;
                            }
                            a {
                                display: inline-block;
                                padding: 15px 30px;
                                font-size: 18px;
                                border-radius: 10px;
                                background-color: #007bff;
                                color: white;
                                text-decoration: none;
                                transition: 0.3s;
                            }
                            a:hover {
                                background-color: #0056b3;
                            }
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h1>Bem vindo!</h1>
                            <a href='/swagger'>Iniciar</a>
                        </div>
                    </body>
                </html>";
            return Content(html, "text/html");
        }
    }
}