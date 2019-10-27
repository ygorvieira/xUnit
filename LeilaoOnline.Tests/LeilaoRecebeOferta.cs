using LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double [] ofertas)
        {
            //Dado leilão finalizado com X lances
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();

            //Quando leilão recebe nova oferta de lance
            leilao.RecebeLance(fulano, 1000);

            //Então a quantidade de lances continua sendo X
            var quantidadeObtida = leilao.Lances.Count();

            Assert.Equal(quantidadeEsperada, quantidadeObtida);
        }
    }
}
