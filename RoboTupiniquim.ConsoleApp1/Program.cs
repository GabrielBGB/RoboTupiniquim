using System;

class RoboTupiniquim
{
    static void Main()
    {
        Console.Write("Digite o tamanho da área (ex: 5 5): ");
        string[] area = Console.ReadLine().Split(' ');
        if (area.Length != 2 || !int.TryParse(area[0], out int largura) || !int.TryParse(area[1], out int altura))
        {
            Console.WriteLine("❌ Entrada inválida para a área. Use o formato: 5 5");
            return;
        }

        while (true)
        {
            Console.Write("\nDigite a posição inicial (ex: 1 2 N) ou ENTER para finalizar: ");
            string linhaPos = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(linhaPos)) break;

            string[] posicao = linhaPos.Split(' ');
            if (posicao.Length != 3 || !int.TryParse(posicao[0], out int x) || !int.TryParse(posicao[1], out int y))
            {
                Console.WriteLine("❌ Entrada inválida para a posição. Use o formato: 1 2 N");
                continue;
            }

            char direcao = char.ToUpper(posicao[2][0]);
            if ("NSLO".IndexOf(direcao) == -1)
            ()
                Console.WriteLine("❌ Direção inválida. Use N, S, L ou O.");
                continue;
            }

            Console.Write("Digite os comandos (ex: EMEMEMEMM): ");
            string comandos = Console.ReadLine().ToUpper();

            foreach (char comando in comandos)
            {
                if (comando == 'E') direcao = VirarEsquerda(direcao);
                else if (comando == 'D') direcao = VirarDireita(direcao);
                else if (comando == 'M')
                {
                    (int novoX, int novoY) = Andar(x, y, direcao);
                    if (novoX >= 0 && novoX <= largura && novoY >= 0 && novoY <= altura)
                    {
                        x = novoX;
                        y = novoY;
                    }
                }
            }

            Console.WriteLine($"{x} {y} {direcao}");
        }
    }

    static char VirarEsquerda(char dir) => dir switch
    {
        'N' => 'O',
        'O' => 'S',
        'S' => 'L',
        'L' => 'N',
        _ => dir
    };

    static char VirarDireita(char dir) => dir switch
    {
        'N' => 'L',
        'L' => 'S',
        'S' => 'O',
        'O' => 'N',
        _ => dir
    };

    static (int, int) Andar(int x, int y, char dir) => dir switch
    {
        'N' => (x, y + 1),
        'S' => (x, y - 1),
        'L' => (x + 1, y),
        'O' => (x - 1, y),
        _ => (x, y)
    };
}