using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void testarPaginacaoCorreta()
        {
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "pagina" + i;

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            Assert.AreEqual(
                 @"<a class=""btn btn-default"" href=""pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""pagina3"">3</a>", resultado.ToString()

                );
        }
    }
}
