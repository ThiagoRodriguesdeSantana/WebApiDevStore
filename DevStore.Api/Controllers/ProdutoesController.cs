using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DevStore.Domain.Modelos;
using DevStore.Infra.DataContexts;

namespace DevStore.Api.Controllers
{
    //Cors possibilita limitar as chamadas da api
    [EnableCors(origins:"*", headers:"*",methods:"*")]
    [RoutePrefix("api/v1/public")]
    public class ProdutoesController : ApiController
    {
        private DevStoreDataContext db = new DevStoreDataContext();

        [Route("produtos")]
        public HttpResponseMessage GetProdutos()
        {
            var resultado = db.Produto.Include("Categoria").ToList();

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }
        [Route("categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var resultado = db.Categoria.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }
        [Route("categorias/{categoriaId}/produtos")]
        public HttpResponseMessage GetProdutoPorCategoria(int categoriaId)
        {
            var resultado = db.Produto.Include("Categoria").Where(c => c.CategoriaId == categoriaId).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }
        [HttpPost]
        [Route("produtos")]
        public HttpResponseMessage PostProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                var resultado = db.Produto;
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Falha ao incluir produto!");
            }

        }

        [HttpPut]
        [Route("produtos")]
        public HttpResponseMessage PutProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Produto>(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                var resultado = db.Produto;
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto!");
            }

        }
        [HttpDelete]
        [Route("produtos")]
        public HttpResponseMessage DeleteProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produto.Remove(db.Produto.Find(produto.Id));
                db.SaveChanges();
                var resultado = db.Produto;
                return Request.CreateResponse(HttpStatusCode.OK, $"Produto [{produto.Id}] excluído!");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto!");
            }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }


    }
}