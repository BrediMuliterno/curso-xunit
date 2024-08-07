using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Theory]
        [InlineData(20)]
        [InlineData(0)]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto(double desconto)
        {
            //Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 7), new DateTime(2024, 2, 5));
            double precoOriginal = 100;
            double precoComDesconto = precoOriginal - desconto;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            //Act
            oferta.Desconto = desconto;

            //Asserts
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Theory]
        [InlineData(120, 30)]
        [InlineData(100, 30)]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualAoPreco(double desconto, double precoComDesconto)
        {
            //Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 7), new DateTime(2024, 2, 5));
            double precoOriginal = 100.0;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            //Act
            oferta.Desconto = desconto;

            //Asserts
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void RetornaPrecoOriginalQuandoDescontoNegativo(double desconto)
        {
            //Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 7), new DateTime(2024, 2, 5));
            double precoOriginal = 100.0;
            //double desconto = -120.0;
            double precoComDesconto = precoOriginal;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            //Act
            oferta.Desconto = desconto;

            //Asserts
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
    }
}
