using System;

public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    private string? artista;
    public string Artista 
    {
        get => artista;
        set
        {
            if (artista = null)
            {
                artista = "Artista desconhecido";
            }
            else
            {
                artista = valeu;
            }
        } 
    }
    private int? anoLancamento;
    public int? AnoLancamento
    {
        get => anoLancamento;
        set
        {
            if (AnoLancamento <= 0)
            {
                anoLancamento = null;
            }
            else
            {
                anoLancamento = value;
            }
        }
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");

    }

    public override string ToString()
    {
        return @$"Id: {Id} Nome: {Nome}";
    }
}

public class TesteExercicio
{
    [Fact]
    public void TesteNomeMusicaInicialziaCorretamente()
    {
        //Arrange
        string nome = "Música Teste";

        //Action
        Musica musica = new Musica(nome);

        //Assert
        Assert.Equal(nome, musica.Nome);
    }

    [Fact]
    public void TesteIdentificadorMusicaInicialziaCorretamente()
    {
        //Arrange
        string id = "Música Identificador";
        int id = 7;

        //Action
        Musica musica = new Musica(nome) {Id = id};

        //Assert
        Assert.Equal(id, musica.Id);
    }

    [Fact]
    public void TesteSaidaMetodoEhString()
    {
        //Arrange
        int id = 1;
        string nome = "Música Teste";
        Musica musica = new Musica(nome);
        musica.Id = id;
        string toStringEsperado = $@"Id: {id} Nome: {nome}";

        //Action
        string resultado = musica.ToString();

        //Assert
        Assert.Equal(toStringEsperado, resultado);
    }
}

public class TesteExercicio2
{
    [Theory]
    [InlineData("Música Teste")]
    [InlineData("Música Teste2")]
    [InlineData("Música Teste3")]
    public void InicializaNomeCorretamenteQuandoCastradaNovaMusica(string nome)
    {
        //Arrange

        //Action
        Musica musica = new Musica(nome);

        //Assert
        Assert.Equal(nome, musica.Nome);
    }

    [Theory]
    [InlineData(1, "Música Teste", "Id: 1 Nome: Música Teste")]
    [InlineData(2, "Música Teste2", "Id: 2 Nome: Música Teste2")]
    [InlineData(3, "Música Teste3", "Id: 3 Nome: Música Teste3")]
    public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoToString(int id, string nome, string toStringEsperado)
    {
        //Arrange
        Musica musica = new Musica(nome);
        musica.Id = id;

        //Action
        string resultado = musica.ToSring();

        //Assert
        Assert.Equal(toStringEsperado, resultado);
    }

    [Theory]
    [InlineData("Música Teste", "Nome: Música Teste")]
    [InlineData("Música Teste2", "Nome: Música Teste2")]
    [InlineData("Música Teste3", "Nome: Música Teste3")]
    public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoExibeFichaTecnica(string nome, string saidaEsperada)
    {
        // Arrange
        Musica musica = new Musica(nome);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        musica.ExibirFichaTecnica();
        string saidaAtual = stringWriter.ToString().Trim();

        // Assert
        Assert.Equal(saidaEsperada, saidaAtual);
    }
}

public class TesteExercicio3
{
    [Fact]
    public void TesteAnoDeLancamentoNuloQuandoValorEhMenorQueZero()
    {
        //Arrange
        int anoInvalido = -1;
        Musica musica = new Musica("Nome");

        //Action
        Musica.AnoLancamento = anoInvalido;

        //Assert
        Assert.Null(musica.AnoLancamento);
    }

    [Fact]
    public void TesteArtistaDesconhecidoQuandoValorEhNulo()
    {
        //Arrange
        Musica musica = new Musica("Nome");

        //Action
        Musica.Artista = null;

        //Assert
        Assert.Equal("Artista desconhecido", musica.Artista);
    }
}

public class TesteExercicio4
{
    [Fact]
    public void RetornaToStringCorretamenteQuandoMusicaEhCadastrada()
    {
        // Arrange
        var faker = new Faker();
        var id = faker.Random.Int();
        var nome = faker.Music.Album();
        var saidaEsperada = $"Id: {id} Nome: {nome}";
        var musica = new Musica(nome) { Id = id };

        // Act
        var result = musica.ToString();

        // Assert
        Assert.Equal(saidaEsperada, result);
    }

    [Fact]
    public void RetornaArtistaDesconhecidoQuandoInseridoDadoNuloNoArtista()
    {
        // Arrange
        var nome = new Faker().Music.Album();
        var musica = new Musica(nome) { Artista = null };

        // Act
        var artista = musica.Artista;

        // Assert
        Assert.Equal("Artista desconhecido", artista);
    }

    [Fact]
    public void RetornoAnoDeLancamentoNuloQuandoValorInseridoMenorQueZero()
    {
        // Arrange
        var nome = new Faker().Music.Album();
        var musica = new Musica(nome) { AnoLancamento = -1 };

        // Act
        var anoLancamento = musica.AnoLancamento;

        // Assert
        Assert.Null(anoLancamento);
    }
}