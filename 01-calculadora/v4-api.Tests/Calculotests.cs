
public class CalculoTests
{
    [Fact]
    public void Soma_Simples()
    {
        bool ok = Calculo.EntradaTexto("2+3", out decimal total);

        Assert.True(ok);
        Assert.Equal(5, total);
    }
}