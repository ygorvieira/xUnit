using LeilaoOnline.Core;
using System;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            if (esperado == obtido)
            {
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.WriteLine("TESTE FALHOU");
            }
        }

        private static void LeilaoComApenasUmLance()
        {
            //Arrange - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            
            leilao.RecebeLance(fulano, 800);
            
            //Act - Método sob teste
            leilao.TerminaPregao();

            //Assert - Verificação
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComVariosLances()
        {
            //Arrange - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            //Act - Método sob teste
            leilao.TerminaPregao();

            //Assert - Verificação
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
