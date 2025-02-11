using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData(null, "Florianopolis", "2024-02-01", "2024-02-05", -1, false)]
        [InlineData("Vit�ria", "Florianopolis", "2024-02-01", "2024-02-01", 0, false)]
        [InlineData("Rio de Janeiro", "S�o Paulo", "2024-02-01", "2024-02-05", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            //cen�rio - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            //a��o - action
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            //Arrange
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            //Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Assert
            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDePeriodoInicialMaiorQuePeriodoFinal()
        {
            //Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 7), new DateTime(2024, 2, 5));
            double preco = 100.0;

            //Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Assert
            Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-250)]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorOuIgualAZero(double preco)
        {
            //Arrange
            Rota rota = new Rota("Origem1", "Destino1");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));

            //Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Assert
            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);

        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
        {
            //Arrange
            int quantidadeEsperada = 3;
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 7), new DateTime(2024, 2, 5));
            double preco = -100.0;

            //Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Assert
            Assert.Equal(quantidadeEsperada, oferta.Erros.Count());
        }
    }
}