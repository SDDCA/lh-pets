using Projeto_Web_Lh_Pets_versao_1;

namespace Projeto_Web_Lh_Pets_Alunos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();


        app.MapGet("/", () => "Projeto Web-LH Pets versao 1");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext context) => {
            context.Response.Redirect("index.html", false);
        });        

        Banco dba = new Banco();
        app.MapGet("/listaClientes", (HttpContext contexto) =>{
            contexto.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
